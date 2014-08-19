using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Model;

namespace Radiostr.Tests.Model
{
    [TestClass]
    public class ScheduleEventTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.DataAnnotations.ValidationException))]
        public void Ctor_TrackHasNullArtist_ThrowsValidationException()
        {
            // Arrange
            var schedule = new Schedule();
            var track = new TrackModel
            {
                Album = new AlbumModel {Name = "album name", Uri = "http://foo.bar"},
                Duration = 1000,
                Title = "Track Title",
                Uri = new[] {"http://foo.bar"}
            };

            // Act
            var @event = new ScheduleEvent(schedule, track);

            Debug.WriteLine(@event);
        }
    }
}
