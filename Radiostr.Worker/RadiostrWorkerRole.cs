using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Radiostr.Model;
using Radiostr.Model.Extensions;
using Radiostr.Services;
using Radiostr.Storage.Queue;
using System.Reactive;
using System.Reactive.Linq;
using Radiostr.Storage.Queue.Extensions;
using Radiostr.Storage.Queue.Models;
using Radiostr.Storage.Table;
using Radiostr.Storage.Table.Entities;

namespace Radiostr.Worker
{
    public class RadiostrWorkerRole : RoleEntryPoint
    {
        private readonly AzureQueueStorage _queue = AzureQueueStorage.GetStorage();
        private IDisposable _subscription;

        public override void Run()
        {
            Trace.TraceInformation("RadiostrWorkerRole RoleEntryPoint Run()");

            Task.WaitAll(
                _queue.CreateQueues(new[] {QueueNames.ImportPlaylist, QueueNames.SelectSchedule}),
                GetTableStorage().CreateTables(new[] {TableNames.Schedule})
                );

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
                await Task.WhenAll(ImportPlaylist(), GeneratePlaylist());
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}\r\n{1}", ex.Message, ex.StackTrace);
                throw;
            }
        }

        private async Task ImportPlaylist()
        {
            var message = await _queue.GetMessage(QueueNames.ImportPlaylist);
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

        private AzureTableStorage GetTableStorage()
        {
            var settings = new NameValueCollection
            {
                {"StorageConnectionString", CloudConfigurationManager.GetSetting("StorageConnectionString")},
            };

            return AzureTableStorage.GetTableStorage(settings);
        }

        private async Task GeneratePlaylist()
        {
            // Get message
            var message = await _queue.GetMessage(QueueNames.ImportPlaylist);
            if (message == null) return;

            var service = SimpleScheduleSelector.GetService();

            try
            {
                var model = message.GetModel<SelectScheduleModel>();
                model.Validate();

                // Select a schedule
                var schedule = await service.Select(model.StationId, model.LibraryIds, model.TrackCount);

                // Save to storage
                var storage = GetTableStorage();
                var entity = new ScheduleTableEntity(schedule);
                await storage.Insert(TableNames.Schedule, entity);
            }
            catch (Exception ex)
            {
                message.SetFailMessage(ex.Message);
                _queue.UpdateMessage(message).Wait();
                throw;
            }

            await _queue.DeleteMessage(message);
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
