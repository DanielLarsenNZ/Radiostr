using System.ComponentModel.DataAnnotations;

namespace Radiostr.Model
{
    /// <summary>
    /// A model for importing a Playlist.
    /// </summary>
    public class PlaylistImportModel
    {
        public const string QueueName = "playlist-import";

        public string UserId { get; set; }
        public string StationId { get; set; }
        public int LibraryId { get; set; }

        [Required]
        public string ServiceName { get; set; }
        
        [Required]
        public string PlaylistId { get; set; }
    }
}
