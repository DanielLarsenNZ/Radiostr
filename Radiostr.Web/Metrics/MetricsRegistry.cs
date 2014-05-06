using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Radiostr.Web.Metrics
{
    /// <summary>
    /// A registry for Metrics objects.
    /// </summary>
    public class MetricsRegistry : IMetricsRegistry
    {
        static readonly ConcurrentBag<Tuple<string, long>> Timings = new ConcurrentBag<Tuple<string, long>>(); 

        /// <summary>
        /// Returns an instance of a Timer.
        /// </summary>
        /// <param name="key">The Key that identifies the timing of this Timer</param>
        /// <returns>A new instance of Timer.</returns>
        public Timer Timer(string key)
        {
            var timer = new Timer(key);
            timer.Stopped += timer_Stopped;
            return timer;
        }

        void timer_Stopped(TimerStoppedEventArgs eventArgs)
        {
            Timings.Add(new Tuple<string, long>(eventArgs.Key, eventArgs.ElapsedMilliseconds));
        }

        /// <summary>
        /// Gets metrics meta data from timer along with aggregate timing data collected so far.
        /// </summary>
        /// <param name="timer">An instance of Timer.</param>
        public MetricsModel GetMetrics(Timer timer)
        {
            var timings = Timings.Where(t => t.Item1 == timer.Key).Select(t => t.Item2).ToList();

            return new MetricsModel
            {
                Key = timer.Key,
                InstanceId = timer.GetHashCode(),
                Time = timer.ElapsedMilliseconds,
                Count = timings.LongCount(),
                Average = timings.Average(),
                Min = timings.Min(),
                Max = timings.Max()
            };
        }
    }
}