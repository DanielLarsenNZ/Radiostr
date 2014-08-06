using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Model.Entities;
using Radiostr.Web.Controllers;

namespace Radiostr.Web.Tests.Controllers
{
    [TestClass]
    public class StationControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public async Task Get()
        {
            // Arrange
            var controller = new StationController();

            // Act
            await controller.Get(new {});
        }

        [TestMethod]
        [TestCategory("integration")]
        public void BigCrudTest()
        {
            // Arrange
            var controller = new StationController();
            int stationOwnerId = new TestHelper().GetTestUser().Id;

            // Act
            var id = controller.Post(new Station { Name = "New test Station", WhenCreated = DateTime.Now, StationOwnerId = stationOwnerId });
            Trace.WriteLine("id = " + id);
            var station = controller.Get(id);
            controller.Put(station);
            station = controller.Get(id);
            controller.Delete(station);
        }

    }
}
