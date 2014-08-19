using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Services;
using Radiostr.Tests.Scenarios;

namespace Radiostr.Tests.Services
{
    [TestClass]
    public class SimpleScheduleSelectorTests
    {
        [TestMethod]
        public async Task BigSelectTest()
        {
            // Arrange
            var result = await new TrackImportScenarios().NewLibraryAndStationAndTracksImported(20);

            var selector = SimpleScheduleSelector.GetService();

            // Act
            var schedule = await selector.Select(result.Item1, new[] {result.Item2}, 10);

            // Assert
            Debug.WriteLine(schedule.ToString());
            Assert.AreEqual(10,schedule.Events.Length);
        }
    }
}
