using System.ComponentModel.DataAnnotations;

namespace Radiostr.Entities
{
    public class TrackUri
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TrackId { get; set; }

        [Url]
        [Required]
        [MaxLength(500)]
        public string Uri { get; set; }
    }
}