using System;
using System.ComponentModel.DataAnnotations;

namespace Radiostr.Model
{
    public class Track
    {
        public int Id { get; set; }

        [MaxLength(400)]
        [Required]
        public string Title { get; set; }

        [MaxLength(400)]
        [Required]
        public string Artist { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
