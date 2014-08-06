using System;
using System.ComponentModel.DataAnnotations;

namespace Radiostr.Model.Entities
{
    public class Station
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        
        public DateTime WhenCreated { get; set; }
        
        [Url]
        public string Url { get; set; }
        
//        [Association("StationOwner", "StationOwnerId", "Id")]
//        public User StationOwner { get; set; }

        [Required]
        public int StationOwnerId { get; set; }
    }
}
