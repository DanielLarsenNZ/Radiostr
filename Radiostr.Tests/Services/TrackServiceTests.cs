using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Entities;
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
            var uid = System.IO.Path.GetRandomFileName();
            var service = TrackService.CreateTrackService();
            var artistService = ArtistService.CreateArtistService();
            
            int artistId = artistService.Create(new Artist {Name = "Beck " + uid});
            Trace.WriteLine("artistId = " + artistId);

            // Act
            int trackId = service.CreateTrack(artistId, "Morning Phase " + uid, "Morning " + uid,
                "https://play.spotify.com/track/3arVrdpOPMgLZOztBr2jM6" + uid, 320);

            Trace.WriteLine("trackId = " + trackId);
        }
    }
}
