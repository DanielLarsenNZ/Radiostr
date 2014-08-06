using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Model;
using Radiostr.Model.Entities;
using Radiostr.Web.Controllers;
using Radiostr.Web.Metrics;

namespace Radiostr.Web.Tests.Controllers
{
    [TestClass]
    public class TrackControllerTests
    {
        [TestMethod]
        [TestCategory("integration")]
        public async Task BigImportTrackTest()
        {
            // Arrange
            string uid = Path.GetRandomFileName();
            var controller = new TrackController();
            var stationController = new StationController();
            var libraryController = new LibraryController();
            int stationOwnerId = new TestHelper().GetTestUser().Id;

            int stationId =
                stationController.Post(new Station
                {
                    Name = "New station " + uid,
                    StationOwnerId = stationOwnerId,
                    WhenCreated = DateTime.Now
                });

            int libraryId = libraryController.Post(new Library
            {
                Name = "New Library " + uid,
                StationId = stationId,
                WhenCreated = DateTime.Now
            });

            var model = new TracksImportModel
            {
                StationId = stationId,
                LibraryId = libraryId,
                Tracks = new[]
                {
                    new TrackModel
                    {
                        Artist = new ArtistModel {Name = "New Artist " + uid},
                        Album = new AlbumModel{Name = "New Album " + uid},
                        Title = "New Title " + uid,
                        Duration = 330000,
                        Uri = "http://new.station.com/" + uid
                    },
                    new TrackModel
                    {
                        Artist = new ArtistModel {Name = "New Artist " + uid},
                        Album = new AlbumModel{Name = "New Album " + uid},
                        Title = "New Title " + uid,
                        Duration = 330000,
                        Uri = "http://new.station.com/" + uid
                    },
                    new TrackModel
                    {
                        Artist = new ArtistModel {Name = "New Artist " + uid},
                        Album = new AlbumModel{Name = "New Album " + uid},
                        Title = "New Title " + uid,
                        Duration = 330000,
                        Uri = "http://new.station.com/2/" + uid
                    }
                }
            };

            //var json = JsonConvert.SerializeObject(model);

            // Act
            for (int i = 0; i < 10; i++)
            {
                await controller.Post(model);
            }
        }
    }
}
