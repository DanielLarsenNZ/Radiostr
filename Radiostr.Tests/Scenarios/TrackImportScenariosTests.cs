using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Radiostr.Tests.Scenarios
{
    [TestClass]
    public class TrackImportScenariosTests
    {
        [TestMethod]
        public async Task NewLibraryAndStationAndTracksImported()
        {
            var scenarios = new TrackImportScenarios();
            var result = await scenarios.NewLibraryAndStationAndTracksImported(10);
            Debug.WriteLine(result.ToString());
        }
    }
}
