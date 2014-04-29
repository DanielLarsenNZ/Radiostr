using System;
using System.ComponentModel.DataAnnotations;

namespace Radiostr.Entities
{
    public class LibraryTrack
    {
        // not used, but must be present for Dapper
        public int Id { get; set; }
        
        [Key]
        [Required]
        public int LibraryId { get; set; }
        
        [Key]
        [Required]
        public int TrackId { get; set; }
        
        [Required]
        public DateTime WhenAdded { get; set; }
    }
}