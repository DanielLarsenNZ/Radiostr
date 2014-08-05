using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Entities;
using Radiostr.Web.Controllers;

namespace Radiostr.Web.Tests.Controllers
{
    [TestClass]
    public class LibraryControllerTests
    {
        [TestMethod]
        [TestCategory("integration")]
        public async Task BigCrudTest()
        {
            // Arrange
            var controller = new LibraryController();
            var stationController = new StationController();
            int stationOwnerId = new TestHelper().GetTestUser().Id;

            // Act
            int stationId =
                stationController.Post(new Station { Name = "Test", StationOwnerId = stationOwnerId, WhenCreated = DateTime.Now });

            var id = controller.Post(new Library { Name = "New test Library", WhenCreated = DateTime.Now, StationId = stationId });
            Trace.WriteLine("id = " + id);
            var entity = controller.Get(id);
            Trace.WriteLine(entity);
            var entities = await controller.Get(new {stationId});
            entities.ToList().ForEach(e=> Trace.WriteLine(e.ToString()));

            controller.Put(entity);
            entity = controller.Get(id);
            controller.Delete(entity);
        }
    }
}
