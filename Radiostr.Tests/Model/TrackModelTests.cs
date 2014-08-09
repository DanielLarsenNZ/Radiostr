//using System.Diagnostics;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Radiostr.Model;
//
//namespace Radiostr.Tests.Model
//{
//    [TestClass]
//    public class TrackModelTests
//    {
//        [TestMethod]
//        public void Version_NewlyCreatedEntity_NoException()
//        {
//            // Arrange
//            
//            // Act
//            var track = new TrackModel("test title", new ArtistModel { Name = "artist name" }, 1000);
//
//            // Assert
//            Debug.WriteLine(track.ToString());
//        }
//
//        [TestMethod]
//        public void PartitionKey_ArtistNameStartsWithM_ReturnsExpectedValue()
//        {
//            // Arrange
//            const string expectedPartitionKey = "Artists_M";
//
//            // Act
//            var track = new TrackModel("Protection", new ArtistModel { Name = "Massive Attack" }, 1000);
//
//            // Assert
//            Assert.AreEqual(expectedPartitionKey, track.PartitionKey);
//            Debug.WriteLine(track.ToString());
//        }
//    }
//}
