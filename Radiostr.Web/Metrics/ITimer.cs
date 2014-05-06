using System;

namespace Radiostr.Web.Metrics
{
    /// <summary>
    /// A Timer object that times the elapsed time between construction and Disposal, or the Stop() method being called.
    /// </summary>
    public interface ITimer : IDisposable
    {
        /// <summary>
        /// Fires when the Timer is stopped.
        /// </summary>
        event Timer.StoppedHandler Stopped;

        /// <summary>
        /// The key to identify the timing of this Timer.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// The Elapsed Milliseconds recorded when the Timer was stopped.
        /// </summary>
        long ElapsedMilliseconds { get; }

        /// <summary>
        /// Stops the Timer.
        /// </summary>
        void Stop();
    }
}