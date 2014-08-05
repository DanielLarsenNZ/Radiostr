using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Radiostr.Model;
using Radiostr.Services;
using Radiostr.Storage.Queue;
using System.Reactive;
using System.Reactive.Linq;
using Radiostr.Storage.Queue.Extensions;

namespace Radiostr.Worker
{
    public class RadiostrWorkerRole : RoleEntryPoint
    {
        private readonly AzureQueueStorage _queue = AzureQueueStorage.GetStorage();
        private IDisposable _subscription;

        public override void Run()
        {
            Trace.TraceInformation("RadiostrWorkerRole RoleEntryPoint Run()");

            _queue.CreateQueues(new[] { PlaylistImportModel.QueueName }).Wait();

            var observable =
                from heartbeat in Observable.Return(0L).Concat(Observable.Interval(TimeSpan.FromSeconds(60)))
                from result in Observable.FromAsync(Execute).Catch(Observable.Empty<Unit>())
                select result;
            _subscription = observable.Subscribe();
        }

        private async Task Execute()
        {
            try
            {
                Trace.TraceInformation("RadiostrWorkerRole RoleEntryPoint Execute()");
                var message = await _queue.GetMessage(PlaylistImportModel.QueueName);

                if (message == null) return;

                var settings = new NameValueCollection
                {
                    {"StorageConnectionString", CloudConfigurationManager.GetSetting("StorageConnectionString")},
                    {"SpotifyApiClientId", CloudConfigurationManager.GetSetting("SpotifyApiClientId")},
                    {"SpotifyApiClientSecret", CloudConfigurationManager.GetSetting("SpotifyApiClientSecret")},
                };

                var service = SpotifyService.GetService(settings);
                
                try
                {
                    await service.ImportPlaylist(message.GetModel<PlaylistImportModel>());
                }
                catch (Exception ex)
                {
                    message.SetFailMessage(ex.Message);
                    _queue.UpdateMessage(message).Wait();
                    throw;
                }

                await _queue.DeleteMessage(message);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}\r\n{1}", ex.Message, ex.StackTrace);
                throw;
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }


        public override void OnStop()
        {
            var subscription = Interlocked.Exchange(ref _subscription, null);
            if (subscription != null)
            {
                subscription.Dispose();
            }
            base.OnStop();  
        }
    }
}
