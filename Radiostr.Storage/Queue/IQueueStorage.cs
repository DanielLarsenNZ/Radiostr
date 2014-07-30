using System.Threading.Tasks;

namespace Radiostr.Storage.Queue
{
    /// <summary>
    /// Defines a Queue Storage object
    /// </summary>
    public interface IQueueStorage
    {
        /// <summary>
        /// Creates queues if they don't already exist.
        /// </summary>
        /// <param name="queueNames">An array of queue names to try and create.</param>
        Task CreateQueues(string[] queueNames);

        /// <summary>
        /// Adds a (string) message to the queue.
        /// </summary>
        Task AddMessage(QueueMessage message);

        /// <summary>
        /// De-queues a message, making it temporarily invisible to other Queue clients.
        /// </summary>
        /// <remarks>Delete the message using <see cref="DeleteMessage"/> when finished processing. If the message is not deleted for any reason it will become 
        /// visible to queue clients again after a set period of time.</remarks>
        Task<QueueMessage> GetMessage(string queueName);

        /// <summary>
        /// Deletes the message from the Queue.
        /// </summary>
        Task DeleteMessage(QueueMessage message);
    }
}
