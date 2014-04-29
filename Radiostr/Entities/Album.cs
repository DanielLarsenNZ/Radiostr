using System.ComponentModel.DataAnnotations;

namespace Radiostr.Entities
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public int ArtistId { get; set; }
    }
}