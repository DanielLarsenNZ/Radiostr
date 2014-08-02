using Microsoft.WindowsAzure.Storage.Queue;

namespace Radiostr.Storage.Queue
{
    /// <summary>
    /// An Abstraction of an Azure CloudQueueMessage that inherits from <see cref="QueueMessage"/> 
    /// </summary>
    public class AzureQueueMessage : QueueMessage
    {
        private readonly CloudQueueMessage _message;
        /// <summary>
        /// Instantiates a new <see cref="AzureQueueMessage"/> with an Azure <see cref="CloudQueueMessage"/>.
        /// </summary>
        public AzureQueueMessage(string queueName, CloudQueueMessage message) : base(queueName, message.AsString)
        {
            _message = message;
        }

        /// <summary>
        /// Returns the underlying <see cref="CloudQueueMessage"/>
        /// </summary>
        /// <returns></returns>
        public CloudQueueMessage GetMessage()
        {
            return _message;
        }

        public override string ToString()
        {
            return
                string.Format(
                    "(Radiostr.Storage.Queue.AzureQueueMessage QueueName = {0}, Message = {1}, CloudQueueMessage.Id = {2})",
                    QueueName,
                    Message, _message.Id);
        }
    }
}
