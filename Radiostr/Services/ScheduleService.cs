using System;
using System.Collections.Generic;
using Radiostr.Model;
using Radiostr.Model.Extensions;

namespace Radiostr.Services
{
    public interface IScheduleService
    {
        Schedule CreateSchedule(string stationId, IEnumerable<TrackModel> tracks);
    }

    public class ScheduleService : IScheduleService
    {
        public Schedule CreateSchedule(string stationId, IEnumerable<TrackModel> tracks)
        {
            if (string.IsNullOrEmpty(stationId)) throw new ArgumentNullException("stationId");
            if (tracks == null) throw new ArgumentNullException("tracks");

            var schedule = new Schedule
            {
                Id = Guid.NewGuid(),
                StationId = stationId
            };

            var events = new List<ScheduleEvent>();
            int sequenceNumber = 0;
            var startTime = new TimeSpan(0);

            foreach (var track in tracks)
            {
                track.Validate();
                var duration = TimeSpan.FromMilliseconds(track.Duration);
                var @event = new ScheduleEvent
                {
                    Track = track,
                    SequenceNumber = ++sequenceNumber,
                    Id = Guid.NewGuid(),
                    StartTime = startTime,
                    Name = string.Format("{0} / {1}", track.Artist.Name, track.Title),
                    StartsOn = StartsOn.EndCue,
                    Duration = duration
                };

                events.Add(@event);
                startTime = startTime.Add(@event.Duration);
            }

            schedule.Events = events.ToArray();
            schedule.Duration = schedule.CalculateDuration();
            return schedule;
        }

        public static ScheduleService GetService()
        {
            return new ScheduleService();
        }
    }
}
