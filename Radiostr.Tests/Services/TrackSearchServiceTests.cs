using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Services;

namespace Radiostr.Tests.Services
{
    [TestClass]
    public class TrackSearchServiceTests
    {
        [TestMethod]
        [TestCategory("integration")]
        public void BigLookupTrackTest()
        {
            // Arrange
            var service = TrackSearchService.CreateService();

            // Act
            int trackId = service.FindTrackByUri("http://spotify.com/track/abc123");
            Trace.WriteLine("trackId = " + trackId);
            
            var result = service.FindTrack("New artist", "New title", "New album");
            string message = result.ToString();
            Trace.WriteLine(message);
        }
    }
}
