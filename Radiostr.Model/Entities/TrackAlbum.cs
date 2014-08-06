using System.ComponentModel.DataAnnotations;

namespace Radiostr.Model.Entities
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
