using System.ComponentModel.DataAnnotations;

namespace Radiostr.Model
{
    /// <summary>
    /// A model for importing a Playlist.
    /// </summary>
    public class PlaylistImportModel
    {
        public const string QueueName = "playlist-import";

        /// <summary>
        /// The Radiostr UserId
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// The Radiostr StationId
        /// </summary>
        public string StationId { get; set; }
        
        /// <summary>
        /// The Radiostr LibraryId
        /// </summary>
        public int LibraryId { get; set; }

        /// <summary>
        /// The name of the Service that hosts the playlist to import, e.g. "spotify".
        /// </summary>
        [Required]
        public string ServiceName { get; set; }
        
        /// <summary>
        /// The Service's Id for the Playlist
        /// </summary>
        [Required]
        public string PlaylistId { get; set; }

        /// <summary>
        /// The Service's UserId for the User that owns the Playlist.
        /// </summary>
        [Required]
        public string PlaylistOwnerId { get; set; }

        /// <summary>
        /// Tags to apply to every track that is imported from this playlist.
        /// </summary>
        public string[] Tags { get; set; }
    }
}
