using System.ComponentModel.DataAnnotations;

namespace Radiostr.Models
{
    public class TrackModel
    {
        [Required]
        [MaxLength(400)]
        public string Title { get; set; }

        [Required]
        public ArtistModel Artist { get; set; }
        
        [MaxLength(200)]
        public string Album { get; set; }

        [Required]
        public float Duration { get; set; }
        
        [Required]
        [Url]
        public string Uri { get; set; }

        public string Mbid { get; set; }
        
        public string Tags { get; set; }

        public override string ToString()
        {
            return string.Format("(TrackModel Title = {0}, Artist = {1}, Duration = {2}, Uri = {3}, Tags = {4})",
                Title, Artist, Duration, Uri, Tags);
        }
    }
}