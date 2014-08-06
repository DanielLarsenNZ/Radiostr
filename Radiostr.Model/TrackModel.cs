using System.ComponentModel.DataAnnotations;

namespace Radiostr.Model
{
    public class TrackModel
    {
        [Required]
        [MaxLength(400)]
        public string Title { get; set; }

        /// <summary>
        /// The Main Artist.
        /// </summary>
        [Required]
        public ArtistModel Artist { get; set; }

        /// <summary>
        /// All Artists listed on the Track.
        /// </summary>
        public ArtistModel[] Artists { get; set; }
        
        public AlbumModel Album { get; set; }

        /// <summary>
        /// Track duration in milliseconds
        /// </summary>
        [Required]
        public int Duration { get; set; }
        
        [Required]
        [Url]
        public string Uri { get; set; }

        public string[] Tags { get; set; }

        public override string ToString()
        {
            return string.Format("(TrackModel Title = {0}, Artist = {1}, Album = {2}, Duration = {3}, Uri = {4}, Tags = {5})",
                Title, Artist, Album, Duration, Uri, Tags);
        }
    }
}