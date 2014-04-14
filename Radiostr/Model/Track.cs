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

        public DateTime Duration { get; set; }

        public override string ToString()
        {
            return string.Format("Id={0}, Title={1}, Artist={2}, Duration={3}", Id, Title, Artist, Duration);
        }
    }
}
