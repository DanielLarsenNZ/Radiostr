using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                service.CreateSchedule("1", new[] { track });
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                throw;
            }
        }

        [TestMethod]
        public void CreateSchedule_10Tracks_LastEventHasSequenceNumber10()
        {
            // Arrange
            var track = new TrackModel
            {
                Album = new AlbumModel {Name = "album name", Uri = "http://foo.bar"},
                Duration = 1000,
                Title = "Track Title",
                Uri = new[] {"http://foo.bar"},
                Artist = new ArtistModel {Id = 1, Name = "Atrist name", Uri = new[] {"http://foo.bar"}}
            };

            var tracks = new List<TrackModel>();
            for (int i = 0; i < 10; i++) tracks.Add(track);
            
            var service = new ScheduleService();

            // Act
            var schedule = service.CreateSchedule("1", tracks);

            // Assert
            Assert.AreEqual(10, schedule.Events.Last().SequenceNumber);
        }

        [TestMethod]
        public void CreateSchedule_TenOneSecondTracks_LastEventHasStartTimeNineSeconds()
        {
            // Arrange
            var track = new TrackModel
            {
                Album = new AlbumModel {Name = "album name", Uri = "http://foo.bar"},
                Duration = 1000,
                Title = "Track Title",
                Uri = new[] {"http://foo.bar"},
                Artist = new ArtistModel {Id = 1, Name = "Atrist name", Uri = new[] {"http://foo.bar"}}
            };

            var tracks = new List<TrackModel>();
            for (int i = 0; i < 10; i++) tracks.Add(track);
            
            var service = new ScheduleService();

            // Act
            var schedule = service.CreateSchedule("1", tracks);

            // Assert
            Assert.AreEqual(TimeSpan.FromSeconds(9), schedule.Events.Last().StartTime);
        }

        [TestMethod]
        public void CreateSchedule_TenOneSecondTracks_ScheduleDuration10Seconds()
        {
            // Arrange
            var track = new TrackModel
            {
                Album = new AlbumModel {Name = "album name", Uri = "http://foo.bar"},
                Duration = 1000,
                Title = "Track Title",
                Uri = new[] {"http://foo.bar"},
                Artist = new ArtistModel {Id = 1, Name = "Atrist name", Uri = new[] {"http://foo.bar"}}
            };

            var tracks = new List<TrackModel>();
            for (int i = 0; i < 10; i++) tracks.Add(track);
            
            var service = new ScheduleService();

            // Act
            var schedule = service.CreateSchedule("1", tracks);

            // Assert
            Assert.AreEqual(TimeSpan.FromSeconds(10), schedule.Duration);
        }
    }
}
