using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Model;
using Radiostr.Services;

namespace Radiostr.Tests.Services
{
    [TestClass]
    public class ScheduleServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.DataAnnotations.ValidationException))]
        public void CreateSchedule_TrackHasNullArtist_ThrowsValidationException()
        {
            // Arrange
            var track = new TrackModel
            {
                Album = new AlbumModel {Name = "album name", Uri = "http://foo.bar"},
                Duration = 1000,
                Title = "Track Title",
                Uri = new[] {"http://foo.bar"}
            };
            var service = new ScheduleService();

            // Act
            try
            {
                service.CreateSchedule(1, new[] { track });
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                throw;
            }
        }
    }
}
