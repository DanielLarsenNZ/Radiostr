using System.ComponentModel.DataAnnotations;

namespace Radiostr.Entities
{
    public class Artist
    {
        [Key]        
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}