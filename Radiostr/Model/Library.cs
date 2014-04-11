using System;
using System.ComponentModel.DataAnnotations;

namespace Radiostr.Model
{
    public class Library
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        
        public DateTime WhenCreated { get; set; }
        
        public int StationId { get; set; }
    }
}
