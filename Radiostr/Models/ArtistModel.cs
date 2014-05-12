using System.ComponentModel.DataAnnotations;

namespace Radiostr.Models
{
    public class ArtistModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Mbid { get; set; }

        public override string ToString()
        {
            return string.Format("(ArtistModel Name = {0}, Mbid = {1})", Name, Mbid);
        }
    }
}