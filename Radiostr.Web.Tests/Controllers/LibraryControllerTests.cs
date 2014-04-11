using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Model;
using Radiostr.Web.Controllers;

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
            controller.Get();
            controller.Put(entity);
            controller.Delete(id);
        }
    }
}
