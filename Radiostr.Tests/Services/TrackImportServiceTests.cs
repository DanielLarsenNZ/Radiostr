using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Entities;
using Radiostr.Model;
using Radiostr.Services;

namespace Radiostr.Tests.Services
{
    [TestClass]
    public class TrackImportServiceTests
    {
        [TestMethod]
        [TestCategory("integration")]
        public async Task BigImportTracksTest()
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

            var model = new TracksImportModel
            {
                LibraryId = libraryId,
                StationId = stationId,
                Tracks = new[]
                {
                    new TrackImportModel
                    {
                        Artist = new ArtistImportModel {Name = "Artist1"},
                        Title = "Title1",
                        Album = new AlbumImportModel{Name = "Album 1"},
                        Duration = 210000,
                        Tags = new []{"nights, reggae"},
                        Uri = "http://spotify.com/track/tr67uw783y"
                    }
                }
            };


            // Act
            await service.ImportTracks(model);

            await service.ImportTracks(model);

            // Assert

        }
    }
}
