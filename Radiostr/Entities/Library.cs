using System;
using System.ComponentModel.DataAnnotations;

namespace Radiostr.Entities
{
    public class Library
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        
        public DateTime WhenCreated { get; set; }
        
        public int StationId { get; set; }

        public override string ToString()
        {
            return
                string.Format("Library(Id = {0}, Name = {1}, Description = {2}, WhenCreated = {3}, StationId = {4})",
                    Id, Name, Description, WhenCreated, StationId);
        }
    }
}
