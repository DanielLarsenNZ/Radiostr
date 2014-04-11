using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Web.Controllers;
using Radiostr.Model;

namespace Radiostr.Web.Tests.Controllers
{
    [TestClass]
    public class StationControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Get()
        {
            // Arrange
            var controller = new StationController();

            // Act
            controller.Get();
        }

        [TestMethod]
        [TestCategory("integration")]
        public void BigCrudTest()
        {
            // Arrange
            var controller = new StationController();

            // Act
            var id = controller.Post(new Station {Name = "New test Station"});
            Trace.WriteLine("id = " + id);
            var station = controller.Get(id);
            controller.Put(station);
            controller.Delete(id);
        }

    }
}
