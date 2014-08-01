using Newtonsoft.Json;

namespace Radiostr.Storage.Queue.Extensions
{
    public static class QueueMessageExtensions
    {
        public static T GetModel<T>(this QueueMessage message)
        {
            return JsonConvert.DeserializeObject<T>(message.GetMessageAsString());
        }
    }
}
