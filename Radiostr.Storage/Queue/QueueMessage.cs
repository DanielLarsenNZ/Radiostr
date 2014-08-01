using System;
using Newtonsoft.Json;

namespace Radiostr.Storage.Queue
{
    public class QueueMessage
    {
        protected readonly string Message;
        protected readonly string QueueName;

        public QueueMessage(string queueName, object messageModel)
        {
            if (string.IsNullOrEmpty(queueName)) throw new ArgumentNullException("queueName");
            if (messageModel == null) throw new ArgumentNullException("messageModel");

            QueueName = queueName;
            Message = JsonConvert.SerializeObject(messageModel);
        }

        public QueueMessage(string queueName, string message)
        {
            if (string.IsNullOrEmpty(queueName)) throw new ArgumentNullException("queueName");
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException("message");
            QueueName = queueName;
            Message = message;
        }

        public string GetQueueName()
        {
            return QueueName;
        }

        public string GetMessageAsString()
        {
            return Message;
        }

    }    
}
