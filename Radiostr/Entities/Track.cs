using System.ComponentModel.DataAnnotations;

namespace Radiostr.Entities
{
    public class Track
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(400)]
        [Required]
        public string Title { get; set; }

        [Required]
        public int ArtistId { get; set; }

        [Required]
        public float Duration { get; set; }

        public override string ToString()
        {
            return string.Format("Id = {0}, Title = {1}, ArtistId = {2}, Duration = {4}", Id, Title,
                ArtistId, Duration);
        }
    }
}
