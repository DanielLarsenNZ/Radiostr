using System.ComponentModel.DataAnnotations;

namespace Radiostr.Models
{
    public class TrackModel
    {
        /*
         * Title = "Title1",
                        Artist = "Artist1",
                        Duration = "3:30",
                        Uri = "http://spotify.com/track/tr67uw783y",
                        Tags = "dub"
         */

        [Required]
        [MaxLength(400)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Artist { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Album { get; set; }

        [Required]
        public float Duration { get; set; }
        
        [Required]
        [Url]
        public string Uri { get; set; }
        
        public string Tags { get; set; }

        public override string ToString()
        {
            return string.Format("Title = {0}, Artist = {1}, Duration = {2}, Uri = {3}, Tags = {4}",
                Title, Artist, Duration, Uri, Tags);
        }
    }
}