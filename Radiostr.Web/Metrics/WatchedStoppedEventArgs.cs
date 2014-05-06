using System;

namespace Radiostr.Web.Metrics
{
    /// <summary>
    /// Event arguments from a Timer.Stopped event.
    /// </summary>
    public class TimerStoppedEventArgs : EventArgs
    {
        public string Key { get; set; }
        public int InstanceId { get; set; }
        public long ElapsedMilliseconds { get; set; }
    }
}