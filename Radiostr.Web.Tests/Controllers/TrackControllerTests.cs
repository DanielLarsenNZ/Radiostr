using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Radiostr.Entities;
using Radiostr.Models;
using Radiostr.Web.Controllers;
using Radiostr.Web.Metrics;

namespace Radiostr.Web.Tests.Controllers
{
    [TestClass]
    public class TrackControllerTests
    {
        [TestMethod]
        [TestCategory("integration")]
        public void BigImportTrackTest()
        {
            // Arrange
            string uid = Path.GetRandomFileName();
            var controller = new TrackController();
            var stationController = new StationController();
            var libraryController = new LibraryController();

            int stationId =
                stationController.Post(new Station
                {
                    Name = "New station " + uid,
                    StationOwnerId = 1,
                    WhenCreated = DateTime.Now
                });

            int libraryId = libraryController.Post(new Library
            {
                Name = "New Library " + uid,
                StationId = stationId,
                WhenCreated = DateTime.Now
            });

            var model = new TrackImportModel
            {
                StationId = stationId,
                LibraryId = libraryId,
                Tracks = new[]
                {
                    new TrackModel
                    {
                        Artist = "New Artist " + uid,
                        Album = "New Album " + uid,
                        Title = "New Title " + uid,
                        Duration = 330f,
                        Uri = "http://new.station.com/" + uid
                    },
                    new TrackModel
                    {
                        Artist = "New Artist " + uid,
                        Album = "New Album " + uid,
                        Title = "New Title " + uid,
                        Duration = 330f,
                        Uri = "http://new.station.com/" + uid
                    },
                    new TrackModel
                    {
                        Artist = "New Artist " + uid,
                        Album = "New Album " + uid,
                        Title = "New Title " + uid,
                        Duration = 310f,
                        Uri = "http://new.station.com/2/" + uid
                    }
                }
            };

            //var json = JsonConvert.SerializeObject(model);

            // Act
            MetricsResult result = null;

            for (int i = 0; i < 10; i++)
            {
                result = controller.Post(model);
            }

            Trace.WriteLine(result.Metrics);

            var messages = (string[])result.Data;
            foreach (string message in messages)
            {
                Trace.WriteLine(message);
            }
        }

    }
}
