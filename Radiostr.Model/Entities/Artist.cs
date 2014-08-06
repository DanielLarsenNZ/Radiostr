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
}