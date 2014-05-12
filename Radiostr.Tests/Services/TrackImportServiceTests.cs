using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Entities;
using Radiostr.Models;
using Radiostr.Services;

namespace Radiostr.Tests.Services
{
    [TestClass]
    public class TrackImportServiceTests
    {
        [TestMethod]
        [TestCategory("integration")]
        public void BigImportTracksTest()
        {
            // Arrange
            var service = TrackImportService.CreateTrackImportService();
            var libraryService = LibraryService.CreateLibraryService();
            var stationService = RadiostrService<Station>.CreateService();
            int stationOwnerId = new TestHelper().GetTestUser().Id;

            int stationId = stationService.Create(new Station
            {
                Name = "New station",
                Description = "New station",
                StationOwnerId = stationOwnerId,
                WhenCreated = DateTime.Now
            });

            int libraryId = libraryService.Create(new Library
            {
                Description = "New library",
                Name = "New Library",
                StationId = stationId,
                WhenCreated = DateTime.Now
            });

            Trace.WriteLine("libraryId = " + libraryId);

            var model = new TrackImportModel
            {
                LibraryId = libraryId,
                StationId = stationId,
                Tracks = new[]
                {
                    new TrackModel
                    {
                        Artist = new ArtistModel {Name = "Artist1"},
                        Title = "Title1",
                        Album = "Album 1",
                        Duration = 210f,
                        Tags = "nights, reggae",
                        Uri = "http://spotify.com/track/tr67uw783y"
                    }
                }
            };


            // Act
            string[] result = service.ImportTracks(model);
            foreach (string message in result)
            {
                Trace.WriteLine(message);
            }

            result = service.ImportTracks(model);
            foreach (string message in result)
            {
                Trace.WriteLine(message);
            }

            // Assert

        }
    }
}
