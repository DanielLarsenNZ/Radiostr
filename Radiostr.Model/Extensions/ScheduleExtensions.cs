using System;
using System.Linq;

namespace Radiostr.Model.Extensions
{
    public static class ScheduleExtensions
    {
        public static TimeSpan CalculateDuration(this Schedule schedule)
        {
            if (schedule.Events == null || schedule.Events.Length == 0) return TimeSpan.FromTicks(0);
            return TimeSpan.FromTicks(schedule.Events.Sum(e => e.Duration.Ticks));
        }

        public static TimeSpan CalculateDuration(this ScheduleEvent scheduleEvent)
        {
            if (scheduleEvent.Track == null) return TimeSpan.FromMilliseconds(0);
            return TimeSpan.FromMilliseconds(scheduleEvent.Track.Duration);
        }

        public static TimeSpan CalculateDuration(this TrackModel track)
        {
            return TimeSpan.FromMilliseconds(track.Duration);
        }

        public static int GetNextEventSequenceNumber(this Schedule schedule)
        {
            if (schedule.Events == null || schedule.Events.Length == 0) return 1;
            return schedule.Events.Max(e => e.SequenceNumber) + 1;
        }

        public static TimeSpan GetNextEventStartTime(this Schedule schedule)
        {
            if (schedule.Events == null || schedule.Events.Length == 0) return TimeSpan.FromMilliseconds(0);
            int number = schedule.Events.Max(e => e.SequenceNumber);
            return
                schedule.Events.Where(e => e.SequenceNumber == number).Select(e => e.StartTime.Add(e.Duration)).First();
        }
    }
}
