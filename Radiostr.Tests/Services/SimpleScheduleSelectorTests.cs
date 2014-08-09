using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Services;

namespace Radiostr.Tests.Services
{
    [TestClass]
    public class SimpleScheduleSelectorTests
    {
        [TestMethod]
        public async Task BigSelectTest()
        {
            // Arrange
            var selector = SimpleScheduleSelector.GetService();

            // Act
            var schedule = await selector.Select(40066, new[] {26045}, 10);     //TODO: Create Library and Station for test.

            // Assert
            Debug.WriteLine(schedule.ToString());
        }
    }
}
