using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Data;
using Radiostr.Helpers;
using Radiostr.Models;
using Radiostr.Services;
using Radiostr.Repositories;
using Moq;

namespace Radiostr.Tests.Services
{
    [TestClass]
    public class StationServiceTests
    {
        [TestMethod]
        [TestCategory("integration")]
        public void BigCrudTestWithGenericService()
        {
            var mockSecurityHelper = new Mock<ISecurityHelper>();
            var repository = new RadiostrRepository<Station>(new RadiostrDbConnection());
            var service = new RadiostrService<Station>(mockSecurityHelper.Object, repository);

            // Act
            int id = service.Create(new Station{Name = "Test Station 1", WhenCreated = DateTime.Now, StationOwnerId = 1});
            Trace.WriteLine("Id = " + id);
            var station = service.Get(id);
            service.Update(station);
            station = service.Get(id);
            service.Delete(station);
        }
    }
}
