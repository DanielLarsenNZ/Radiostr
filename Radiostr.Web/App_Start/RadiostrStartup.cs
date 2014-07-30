using Radiostr.Model;
using Radiostr.Storage.Queue;
using Scale.Logger;

namespace Radiostr.Web
{
    public class RadiostrStartup
    {
        public static void Startup()
        {
            // init queues
            var queue = new AzureQueueStorage(new LoggerRegistry());
            queue.CreateQueues(new[] {PlaylistImportModel.QueueName}).Wait();
        }
    }
}