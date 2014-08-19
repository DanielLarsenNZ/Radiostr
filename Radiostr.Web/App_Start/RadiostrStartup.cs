using Radiostr.Storage.Queue;

namespace Radiostr.Web
{
    public class RadiostrStartup
    {
        public static void Startup()
        {
            // init queues
            var queue = AzureQueueStorage.GetStorage();
            queue.CreateQueues(new[] { QueueNames.ImportPlaylist, QueueNames.SelectSchedule }).Wait();
        }
    }
}