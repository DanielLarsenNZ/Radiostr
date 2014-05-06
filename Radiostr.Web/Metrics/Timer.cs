using System;
using System.Diagnostics;

namespace Radiostr.Web.Metrics
{
    /// <summary>
    /// A Timer object that times the elapsed time between construction and Disposal, or the Stop() method being called.
    /// </summary>
    public class Timer : ITimer
    {
        private readonly Stopwatch _stopwatch;
        public delegate void StoppedHandler(TimerStoppedEventArgs eventArgs);
        
        /// <summary>
        /// Fires when the Timer is stopped.
        /// </summary>
        public event StoppedHandler Stopped;

        /// <summary>
        /// The key to identify the timing of this Timer.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// The Elapsed Milliseconds recorded when the Timer was stopped.
        /// </summary>
        public long ElapsedMilliseconds { get; private set; }

        /// <summary>
        /// Constructs a new Timer.
        /// </summary>
        /// <param name="key"></param>
        public Timer(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException();
            Key = key;

            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        /// <summary>
        /// Stops the Timer.
        /// </summary>
        public void Stop()
        {
            _stopwatch.Stop();

            ElapsedMilliseconds = _stopwatch.ElapsedMilliseconds;
            
            Stopped(new TimerStoppedEventArgs
            {
                ElapsedMilliseconds = ElapsedMilliseconds,
                Key = Key,
                InstanceId = GetHashCode()
            });
        }

        /// <summary>
        /// Stops the Timer before disposal of the object.
        /// </summary>
        public void Dispose()
        {
            Stop();
        }
    }
}