using System.ComponentModel.DataAnnotations;

namespace Radiostr.Entities
{
    public class TrackAlbum
    {
        [Key]
        [Required]
        public int TrackId { get; set; }

        [Key]
        [Required]
        public int AlbumId { get; set; }
    }
}
