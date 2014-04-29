using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Entities;
using Radiostr.Web.Controllers;
using System.Linq;

namespace Radiostr.Web.Tests.Controllers
{
    [TestClass]
    public class LibraryControllerTests
    {
        [TestMethod]
        [TestCategory("integration")]
        public void BigCrudTest()
        {
            // Arrange
            var controller = new LibraryController();
            var stationController = new StationController();

            // Act
            int stationId =
                stationController.Post(new Station {Name = "Test", StationOwnerId = 1, WhenCreated = DateTime.Now});

            var id = controller.Post(new Library { Name = "New test Library", WhenCreated = DateTime.Now, StationId = stationId });
            Trace.WriteLine("id = " + id);
            var entity = controller.Get(id);
            Trace.WriteLine(entity);
            var entities = controller.Get(new {stationId});
            entities.ToList().ForEach(e=> Trace.WriteLine(e.ToString()));

            controller.Put(entity);
            entity = controller.Get(id);
            controller.Delete(entity);
        }
    }
}
