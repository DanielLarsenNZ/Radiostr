using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Radiostr.Storage.Queue;

namespace Radiostr.Storage.Tests.Queue
{
    [TestClass]
    public class QueueMessageTests
    {
        [TestMethod]
        public void SetFailMessage_Data_DataIsNotChanged()
        {
            // Arrange
            const string testMessage =
                "{\"Data\":{\"UserId\":\"1\",\"StationId\":\"37034\",\"LibraryId\":0,\"ServiceName\":\"spotify\",\"PlaylistId\":\"3g5czEDZgJqKNPajOy0P4G\",\"ServiceUserId\":\"DanielLarsenNZ\",\"Tags\":[\"spotify\",\"new shit\",\"1275028882\"]},\"FailCount\":0,\"FailMessage\":null}";
            var message = new QueueMessage("test", testMessage);

            // Act
            message.SetFailMessage("Failed.");
            dynamic messageModel = JsonConvert.DeserializeObject(message.GetMessageAsString());
            dynamic expectedMessageModel = JsonConvert.DeserializeObject(testMessage);

            // Assert
            Assert.AreEqual(expectedMessageModel.Data.ToString(), messageModel.Data.ToString());
        }

        [TestMethod]
        public void GetMessageAsString_Data_FailCountEquals0()
        {
            // Arrange
            const string testMessage =
                "{\"Data\":{\"UserId\":\"1\",\"StationId\":\"37034\",\"LibraryId\":0,\"ServiceName\":\"spotify\",\"PlaylistId\":\"3g5czEDZgJqKNPajOy0P4G\",\"ServiceUserId\":\"DanielLarsenNZ\",\"Tags\":[\"spotify\",\"new shit\",\"1275028882\"]},\"FailCount\":0,\"FailMessage\":null}";
            var message = new QueueMessage("test", testMessage);

            // Act
            dynamic messageModel = JsonConvert.DeserializeObject(message.GetMessageAsString());

            // Assert
            Assert.AreEqual(0, (int)messageModel.FailCount);
        }

        [TestMethod]
        public void SetFailMessage_Data_FailCountEquals1()
        {
            // Arrange
            const string testMessage =
                "{\"Data\":{\"UserId\":\"1\",\"StationId\":\"37034\",\"LibraryId\":0,\"ServiceName\":\"spotify\",\"PlaylistId\":\"3g5czEDZgJqKNPajOy0P4G\",\"ServiceUserId\":\"DanielLarsenNZ\",\"Tags\":[\"spotify\",\"new shit\",\"1275028882\"]},\"FailCount\":0,\"FailMessage\":null}";
            var message = new QueueMessage("test", testMessage);

            // Act
            message.SetFailMessage("Failed.");
            dynamic messageModel = JsonConvert.DeserializeObject(message.GetMessageAsString());

            // Assert
            Assert.AreEqual(1, (int)messageModel.FailCount);
        }
    }
}
