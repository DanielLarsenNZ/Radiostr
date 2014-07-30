using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceRuntime;
using Radiostr.Model;
using Radiostr.Storage.Queue;
using System.Reactive;
using System.Reactive.Linq;
using Scale.Logger;

namespace Radiostr.Worker
{
    public class RadiostrWorkerRole : RoleEntryPoint
    {
        private readonly AzureQueueStorage _queue = new AzureQueueStorage(new LoggerRegistry());
        private IDisposable _subscription;

        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.TraceInformation("RadiostrWorkerRole entry point called");

            _queue.CreateQueues(new[] { PlaylistImportModel.QueueName }).Wait();

            var observable =
                from heartbeat in Observable.Return(0L).Concat(Observable.Interval(TimeSpan.FromSeconds(60)))
                from result in Observable.FromAsync(Execute).Catch(Observable.Empty<Unit>())
                select result;
            _subscription = observable.Subscribe();

        }

        private async Task Execute()
        {
            Trace.TraceInformation("Execute");
            var message = await _queue.GetMessage(PlaylistImportModel.QueueName);
            
            if (message == null)
            {
                Trace.TraceInformation("No message on Queue");
                return;
            }

            Trace.TraceInformation(message.GetMessageAsString());
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
