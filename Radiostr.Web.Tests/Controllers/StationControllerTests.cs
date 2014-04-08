using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Web;
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
