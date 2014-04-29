using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Entities;
using Radiostr.Models;
using Radiostr.Web.Controllers;

namespace Radiostr.Web.Tests.Controllers
{
    [TestClass]
    public class TrackControllerTests
    {
        [TestMethod]
        [TestCategory("integration")]
        public void BigCrudTest()
        {
            throw new NotImplementedException();

//            // Arrange
//            var controller = new TrackController();
//
//            // Act
//            var id =
//                controller.Post(new Track
//                {
//                    Title = "New title",
//                    Artist = "New Artist",
//                    Duration = new DateTime(1900, 1, 1).Add(new TimeSpan(0, 3, 30))
//                });
//            
//            Trace.WriteLine("id = " + id);
//            
//            var track = controller.Get(id);
//
//            Trace.WriteLine(track);
//
//            controller.Put(track);
//            track = controller.Get(id);
//            controller.Delete(track);
        }

        [TestMethod]
        [TestCategory("integration")]
        public void BigPostTrackModelTest()
        {

            throw new NotImplementedException();

            /*
            {
                StationId: 123,
                LibraryId: 456,
                Tracks: []
                {
                    Title: "Title",
                    Artist: "Artist",
                    Duration: "3:30",
                    Uri: "http://spotify.com/track/tr67uw783y",
                    Tags: "reggae, dub"
                }
            }
             */

//            // Arrange
//            var stationController = new StationController();
//
//            // Act
//            var stationId = stationController.Post(new Station { Name = "New test Station", WhenCreated = DateTime.Now, StationOwnerId = 1 });
//            Trace.WriteLine("stationId = " + stationId);
//            var controller = new TrackController();
//
//            dynamic trackModel = new
//            {
//                StationId = stationId,
//                LibraryId = 456,
//                Tags = "nights, reggae",
//                Tracks = new []
//                {
//                    new
//                    {
//                        Title = "Title1",
//                        Artist = "Artist1",
//                        Duration = "3:30",
//                        Uri = "http://spotify.com/track/tr67uw783y",
//                        Tags = "dub"
//
//                    },
//                    new
//                    {
//                        Title = "Title2",
//                        Artist = "Artist2",
//                        Duration = "3:32",
//                        Uri = "http://spotify.com/track/tr67uw783y",
//                        Tags = "ska, sun-studios"
//                    }
//                }
//            };
//
//            // Act
//            controller.Post(trackModel);
//
//            // Assert

        }
    }
}
