﻿using System.ComponentModel.DataAnnotations;

namespace Radiostr.Model
{
    /// <summary>
    /// A model for importing an Artist
    /// </summary>
    public class ArtistImportModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Uri { get; set; }

        public override string ToString()
        {
            return string.Format("(ArtistModel Name = {0}, Uri = {1}", Name, Uri);
        }
    }
}