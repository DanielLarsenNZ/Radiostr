using System;
using System.ComponentModel.DataAnnotations;

namespace Radiostr.Model
{
    /// <summary>
    /// A basic time-based list of events (tracks).
    /// </summary>
    public class Schedule
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string StationId { get; set; }

        /// <summary>
        /// Optional sequence hash used for ordering schedules in a list.
        /// </summary>
        [Required]
        public int SequenceNumber { get; set; }
        
        /// <summary>
        /// An optional start time for this Schedule.
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// If StartTime is set, allows the precision of the start-time to be set.
        /// </summary>
        public DateTimePrecision? StartTimePrecision { get; set; }

        /// <summary>
        /// What triggers the first start-cue of this schedule.
        /// </summary>
        public StartsOn StartsOn { get; set; }

        /// <summary>
        /// The calculated duration of this schedule from first start-cue to last end-cue.
        /// </summary>
        public TimeSpan Duration { get; set; }
        
        /// <summary>
        /// The schedule events of this schedule.
        /// </summary>
        public ScheduleEvent[] Events { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "(Schedule StationId={0}, SequenceNumber={1}, StartTime={2}, StartTimePrecision={3}, StartsOn={4}, Duration={5}, Events={6})",
                    StationId, SequenceNumber, StartTime, StartTimePrecision, StartsOn, Duration,
                    Events == null ? "" : string.Format("(ScheduleEvent[] Length={0})", Events.Length));
        }
    }

    public class ScheduleEvent
    {
        /// <summary>
        /// Sequence hash used for ordering schedule events in this schedule.
        /// </summary>
        [Required]
        public int SequenceNumber { get; set; }

        /// <summary>
        /// The start time of the schedule event, relative to the start time of the schedule.
        /// </summary>
        [Required]
        public TimeSpan StartTime { get; set; }
        
        /// <summary>
        /// The calculated duration of the schedule event from start-cue to end-cue.
        /// </summary>
        [Required]
        public TimeSpan Duration { get; set; }
        
        /// <summary>
        /// The schedule event Id.
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// A name for the schedule event.
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// A description for the schedule event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// What triggers the start-cue of this schedule event.
        /// </summary>
        public StartsOn StartsOn { get; set; }
        
        /// <summary>
        /// The schedule event that cues the start of this schedule event.
        /// </summary>
        public int CueEventId { get; set; }
        
        /// <summary>
        /// A track to play for this schedule event.
        /// </summary>
        public TrackModel Track { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "(ScheduleEvent SequenceNumber={0}, StartTime={1}, Duration={2}, Id={3}, Name={4}, Description={5}, StartsOn={6}, CueEventId={7}, Track={8})",
                    SequenceNumber, StartTime, Duration, Id, Name, Description, StartsOn, CueEventId, Track);
        }
    }

    /// <summary>
    /// Type of event that would trigger a schedule or a schedule event.
    /// </summary>
    public enum StartsOn
    {
        /// <summary>
        /// End-cue of previous schedule event.
        /// </summary>
        EndCue,

        /// <summary>
        /// At or as soon after the specified start time.
        /// </summary>
        AsapTime,

        /// <summary>
        /// At the exact specified start time.
        /// </summary>
        ExactTime,

        /// <summary>
        /// On the end-cue of the cue schedule event.
        /// </summary>
        EndCueOf

        //StartCueOf...
    }

    /// <summary>
    /// Type of precision to associate with a DateTime value.
    /// </summary>
    public enum DateTimePrecision
    {
        /// <summary>
        /// Use the absolute date and time for scheduling.
        /// </summary>
        DateAndTime,

        /// <summary>
        /// Only use the Date portion for scheduling.
        /// </summary>
        DateOnly,

        /// <summary>
        /// Only use the Time portion for scheduling.
        /// </summary>
        TimeOnly
    }
}
