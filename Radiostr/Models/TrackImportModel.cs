using System.ComponentModel.DataAnnotations;

namespace Radiostr.Models
{
    public class TrackImportModel
    {
        /*
         * dynamic trackModel = new
            {
                StationId = stationId,
                LibraryId = 456,
                Tags = "nights, reggae",
                Tracks = new []
                {
                    new
                    {
                        Title = "Title1",
                        Artist = "Artist1",
                        Duration = "3:30",
                        Uri = "http://spotify.com/track/tr67uw783y",
                        Tags = "dub"
                    }
                }
            };
         * */

        [Required]
        public int StationId { get; set; }

        [Required]
        public int LibraryId { get; set; }

        public string Tags { get; set; }

        public TrackModel[] Tracks { get; set; }
    }
}