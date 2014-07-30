using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Scale.Logger;

namespace Radiostr.Storage.Queue
{
    /// <summary>
    /// A Queue Storage service based on Azure Queue Storage.
    /// </summary>
    public class AzureQueueStorage : IQueueStorage
    {
        private readonly CloudQueueClient _queueClient;
        private readonly ILogger _log;

        private static readonly Lazy<string> ConnectionString =
            new Lazy<string>(() => CloudConfigurationManager.GetSetting("StorageConnectionString"));

        /// <summary>
        /// Instantiates a new <see cref="AzureQueueStorage"/> service.
        /// </summary>
        public AzureQueueStorage(ILoggerRegistry loggerRegistry)
        {
            _log = loggerRegistry.Logger("Radiostr.Storage.Queue.AzureQueueStorage");

            var storageAccount = CloudStorageAccount.Parse(ConnectionString.Value);

            // Create the queue client
            _queueClient = storageAccount.CreateCloudQueueClient();
        }

        public async Task CreateQueues(string[] queueNames)
        {
            if(queueNames == null || queueNames.Length == 0) throw new ArgumentNullException("queueNames");
            foreach (string queueName in queueNames.AsParallel())   //REVIEW
            {
                _log.Message("CreateIfNotExistsAsync " + queueName);
                var queue = _queueClient.GetQueueReference(queueName);
                await queue.CreateIfNotExistsAsync();
            }
        }

        /// <summary>
        /// Adds a (string) message to the queue.
        /// </summary>
        public async Task AddMessage(QueueMessage message)
        {
            _log.Message("AddMessage " + message);

            // Retrieve a reference to a queue
            var queue = _queueClient.GetQueueReference(message.GetQueueName());

            // Create a message and add it to the queue.
            var queueMessage = new CloudQueueMessage(message.GetMessageAsString());
            await queue.AddMessageAsync(queueMessage);
        }

        /// <summary>
        /// De-queues a message, making it temporarily invisible to other Queue clients.
        /// </summary>
        /// <remarks>Delete the message using <see cref="DeleteMessage"/> when finished processing. If the message is not deleted for any reason it will become 
        /// visible to queue clients again after a set period of time.</remarks>
        public async Task<QueueMessage> GetMessage(string queueName)
        {
            // Get the next message
            var queue = _queueClient.GetQueueReference(queueName);
            var message = await queue.GetMessageAsync();

            _log.Message("GetMessage({0}) = {1}", new object[] {queueName, message});
            
            if (message == null) return null;
            return new AzureQueueMessage(queueName, message);
        }

        /// <summary>
        /// Deletes the message from the Queue.
        /// </summary>
        /// <seealso cref="GetMessage"/>
        public async Task DeleteMessage(QueueMessage message)
        {
            _log.Message("DeleteMessage " + message);

            var cloudMessage = message as AzureQueueMessage;
            if (cloudMessage == null) throw new ArgumentException("Message must be type of AzureQueueMessage");
            var queue = _queueClient.GetQueueReference(message.GetQueueName());
            await queue.DeleteMessageAsync(cloudMessage.GetMessage());
        }
    }
}
