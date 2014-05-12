using System.ComponentModel.DataAnnotations;

namespace Radiostr.Models
{
    public class TrackImportModel
    {
        [Required]
        public int StationId { get; set; }

        [Required]
        public int LibraryId { get; set; }

        public string Tags { get; set; }

        public TrackModel[] Tracks { get; set; }
    }
}