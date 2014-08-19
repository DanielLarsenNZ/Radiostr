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
    }
}
