using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Radiostr.Storage.Queue
{
    /// <summary>
    /// A Queue Storage service based on Azure Queue Storage.
    /// </summary>
    public class AzureQueueStorage : AzureStorage, IQueueStorage
    {
        private readonly CloudQueueClient _queueClient;

        /// <summary>
        /// Instantiates a new <see cref="AzureQueueStorage"/> service.
        /// </summary>
        internal AzureQueueStorage(NameValueCollection settings) : base(settings)
        {
            _queueClient = StorageAccount.CreateCloudQueueClient();
        }

        public async Task CreateQueues(string[] queueNames)
        {
            if(queueNames == null || queueNames.Length == 0) throw new ArgumentNullException("queueNames");
            foreach (string queueName in queueNames.AsParallel())   //REVIEW
            {
                var queue = _queueClient.GetQueueReference(queueName);
                await queue.CreateIfNotExistsAsync();
                Trace.TraceInformation("Created Queue " + queueName);
            }
        }

        /// <summary>
        /// Adds a (string) message to the queue.
        /// </summary>
        public async Task AddMessage(QueueMessage message)
        {
            // Retrieve a reference to a queue
            var queue = _queueClient.GetQueueReference(message.GetQueueName());

            // Create a message and add it to the queue.
            var queueMessage = new CloudQueueMessage(message.GetMessageAsString());
            await queue.AddMessageAsync(queueMessage);
            Trace.TraceInformation("Added Message " + message);
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

            var message = await queue.GetMessageAsync(GetVisibilityTime(), null, null);

            if (message == null)
            {
                Trace.TraceInformation("No messages on queue {0}", queueName);
                return null;
            }

            var queueMessage = new AzureQueueMessage(queueName, message);
            Trace.TraceInformation("Got Message {0}", queueMessage);
            return queueMessage;
        }

        private TimeSpan GetVisibilityTime()
        {
            string visibilitySettingValue = Settings["AzureQueueStorageGetMessageVisibilityTime"];
            int visibilitySeconds;
            int.TryParse(visibilitySettingValue, out visibilitySeconds);

            var visibilityTime = visibilitySeconds > 0
                ? TimeSpan.FromSeconds(visibilitySeconds)
                : TimeSpan.FromSeconds(30);
            return visibilityTime;
        }

        public async Task UpdateMessage(QueueMessage message)
        {
            var cloudMessage = message as AzureQueueMessage;
            if (cloudMessage == null) throw new ArgumentException("Message must be type of AzureQueueMessage");

            var cloudQueueMessage = cloudMessage.GetMessage();
            cloudQueueMessage.SetMessageContent(cloudMessage.GetMessageAsString());

            var queue = _queueClient.GetQueueReference(cloudMessage.GetQueueName());
            await
                queue.UpdateMessageAsync(cloudQueueMessage, GetVisibilityTime(),
                    MessageUpdateFields.Content | MessageUpdateFields.Visibility);
            Trace.TraceInformation("Updated Message " + cloudMessage);
        }

        /// <summary>
        /// Deletes the message from the Queue.
        /// </summary>
        /// <seealso cref="GetMessage"/>
        public async Task DeleteMessage(QueueMessage message)
        {
            var cloudMessage = message as AzureQueueMessage;
            if (cloudMessage == null) throw new ArgumentException("Message must be type of AzureQueueMessage");
            
            var queue = _queueClient.GetQueueReference(message.GetQueueName());
            await queue.DeleteMessageAsync(cloudMessage.GetMessage());
            Trace.TraceInformation("Deleted Message " + message);
        }

        public static AzureQueueStorage GetStorage()
        {
            return new AzureQueueStorage(new NameValueCollection
            {
                {"StorageConnectionString", CloudConfigurationManager.GetSetting("StorageConnectionString")},
                {
                    "AzureQueueStorageGetMessageVisibilityTime",
                    CloudConfigurationManager.GetSetting("AzureQueueStorageGetMessageVisibilityTime")
                }
            });
        }
    }
}
