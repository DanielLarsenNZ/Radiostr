using System;
using System.ComponentModel.DataAnnotations;

namespace Radiostr.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Username { get; set; }

        [MaxLength(200)]
        [Required]
        public string FullName { get; set; }

        [MaxLength(200)]
        public string TwitterHandle { get; set; }
        
        [Url]
        public string Url { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public DateTime WhenCreated { get; set; }
    }
}
