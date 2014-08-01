using System.ComponentModel.DataAnnotations;

namespace Radiostr.Model
{
    public class AlbumImportModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Uri { get; set; }

        public override string ToString()
        {
            return string.Format("(AlbumModel Name = {0}, Uri = {1})", Name, Uri);
        }
    }
}
