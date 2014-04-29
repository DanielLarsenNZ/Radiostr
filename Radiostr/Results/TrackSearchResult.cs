namespace Radiostr.Results
{
    public class TrackSearchResult
    {
        public bool Found { get; set; }
        public string Message { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public int TrackId { get; set; }
    }
}