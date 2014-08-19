using System.ComponentModel.DataAnnotations;

namespace Radiostr.Storage.Queue.Models
{
    public class SelectScheduleModel
    {
        /// <summary>
        /// The Radiostr UserId
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// The StationId
        /// </summary>
        [Required]
        public string StationId { get; set; }

        /// <summary>
        /// The LibraryIds to select from.
        /// </summary>
        [Required]
        public int[] LibraryIds { get; set; }

        /// <summary>
        /// The number of tracks to select.
        /// </summary>
        public int TrackCount { get; set; }
    }
}
