using System.ComponentModel.DataAnnotations;

namespace Radiostr.Model
{
    public class TracksImportModel
    {
        [Required]
        public int StationId { get; set; }

        [Required]
        public int LibraryId { get; set; }

        public string[] Tags { get; set; }

        public TrackImportModel[] Tracks { get; set; }
    }
}