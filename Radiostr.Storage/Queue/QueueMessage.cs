using System;
using Newtonsoft.Json;

namespace Radiostr.Storage.Queue
{
    public class QueueMessage
    {
        protected string Message;
        protected readonly string QueueName;
        public readonly object Data;

        /// <summary>
        /// This constructor is used when adding a message to the queue.
        /// </summary>
        /// <param name="queueName">The queue name.</param>
        /// <param name="data">An object to serialise into the data of the message.</param>
        public QueueMessage(string queueName, object data)
        {
            if (string.IsNullOrEmpty(queueName)) throw new ArgumentNullException("queueName");
            if (data == null) throw new ArgumentNullException("data");

            QueueName = queueName;
            Data = data;
            SerializeDataToMessage();
        }

        /// <summary>
        /// This constructor is used when getting a message from the queue.
        /// </summary>
        /// <param name="queueName">The queue name.</param>
        /// <param name="message">The raw message as string.</param>
        public QueueMessage(string queueName, string message)
        {
            if (string.IsNullOrEmpty(queueName)) throw new ArgumentNullException("queueName");
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException("message");
            QueueName = queueName;
            Message = message;
            dynamic messageModel = JsonConvert.DeserializeObject(Message);
            Data = messageModel.Data;
        }

        public void SetFailMessage(string failMessage)
        {
            if (Data == null) throw new InvalidOperationException();    //REFACTOR - this is getting smelly
            SerializeDataToMessage(failMessage);
        }

        public string GetQueueName()
        {
            return QueueName;
        }

        /// <summary>
        /// Gets the entire raw message (including data) as string.
        /// </summary>
        /// <returns></returns>
        public string GetMessageAsString()
        {
            return Message;
        }

        public override string ToString()
        {
            return string.Format("(Radiostr.Storage.Queue.QueueMessage QueueName = {0}, Message = {1})", QueueName,
                Message);
        }

        protected internal void SerializeDataToMessage(string failMessage = null)
        {
            int failCount = 0;
            if (Message != null)
            {
                dynamic message = JsonConvert.DeserializeObject(Message);
                failCount = message.FailCount;
            }

            if (!string.IsNullOrEmpty(failMessage)) failCount++;
            Message = JsonConvert.SerializeObject(new { Data , FailMessage = failMessage, FailCount = failCount });
        }
    }    
}
