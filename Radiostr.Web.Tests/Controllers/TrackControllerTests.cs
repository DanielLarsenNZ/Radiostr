using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Model;
using Radiostr.Web.Controllers;

namespace Radiostr.Web.Tests.Controllers
{
    [TestClass]
    public class TrackControllerTests
    {
        [TestMethod]
        [TestCategory("integration")]
        public void BigCrudTest()
        {
            // Arrange
            var controller = new TrackController();

            // Act
            var id =
                controller.Post(new Track
                {
                    Title = "New title",
                    Artist = "New Artist",
                    Duration = new DateTime(1900, 1, 1).Add(new TimeSpan(0, 3, 30))
                });
            
            Trace.WriteLine("id = " + id);
            
            var track = controller.Get(id);

            Trace.WriteLine(track);

            controller.Put(track);
            track = controller.Get(id);
            controller.Delete(track);
        }
    }
}
