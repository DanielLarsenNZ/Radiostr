using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Radiostr.Model;
using Radiostr.Model.Entities;
using Radiostr.Services;
using Radiostr.Tests.Services;

namespace Radiostr.Tests.Scenarios
{
    internal class TrackImportScenarios
    {
        internal async Task<Tuple<int, int>> NewLibraryAndStationAndTracksImported(int numberOfTracks)
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

            var tracks = new TrackModel[numberOfTracks];
            for (int i = 0; i < numberOfTracks; i++)
            {
                var uid = TestHelper.NewUid();

                tracks[i] = new TrackModel
                {
                    Artist = new ArtistModel {Name = "Test Artist " + uid},
                    Title = "Test Track " + uid,
                    Album = new AlbumModel {Name = "Test Album " + uid},
                    Duration = 200000,
                    Tags = new[] {"test"},
                    Uri = new[] {"test:track:" + uid}
                };
            }

            var model = new TracksImportModel
            {
                LibraryId = libraryId,
                StationId = stationId,
                Tracks = tracks
            };

            // Act
            await service.ImportTracks(model);

            return new Tuple<int, int>(stationId, libraryId);
        }
    }
}
