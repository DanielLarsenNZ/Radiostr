using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Radiostr.Entities;
using Radiostr.Helpers;
using Radiostr.Repositories;
using Radiostr.Services;

namespace Radiostr.Tests.Services
{
    [TestClass]
    public class TrackServiceTests
    {
        [TestMethod]
        [TestCategory("integration")]
        public void CreateTrackTest()
        {
            // Arrange
            var uid = new TestHelper().GetUid();
            var service = TrackService.CreateTrackService();
            var artistService = ArtistService.CreateArtistService();
            
            int artistId = artistService.Create(new Artist {Name = "Beck " + uid});
            Trace.WriteLine("artistId = " + artistId);

            // Act
            int trackId = service.CreateTrack(artistId, "Morning " + uid,
                "https://play.spotify.com/track/3arVrdpOPMgLZOztBr2jM6" + uid, 320);

            Trace.WriteLine("trackId = " + trackId);
        }

        [TestMethod]
        public void CreateTrack_AlbumId_AlbumRepositoryCreateCalled()
        {
            // Arrange
            const int albumId = 1;
            const int artistId = 2;
            var uid = new TestHelper().GetUid();

            var mockSecurityHelper = new Mock<ISecurityHelper>();
            var mockTrackRepository = new Mock<IRepository<Track>>();
            var mockTrackAlbumRepository = new Mock<ITrackAlbumRepository>();
            var mockTrackUriRepository = new Mock<IRepository<TrackUri>>();

            var service = new TrackService(mockSecurityHelper.Object, mockTrackRepository.Object,
                mockTrackAlbumRepository.Object, mockTrackUriRepository.Object);

            // Act
            service.CreateTrack(artistId, albumId, "Morning " + uid, "https://play.spotify.com/track/3arVrdpOPMgLZOztBr2jM6" + uid, 320);

            // Assert
            mockTrackAlbumRepository.Verify(r => r.Create(It.IsAny<int>(), albumId));
        }
    }
}
