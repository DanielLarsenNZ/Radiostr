using System.ComponentModel.DataAnnotations;

namespace Radiostr.Model.Entities
{
    public class Artist
    {
        [Key]        
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }

    public class ArtistUri
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int ArtistId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Uri { get; set; }
    }
}