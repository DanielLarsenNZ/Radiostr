using Radiostr.Results;

namespace Radiostr.Services
{
    public interface ITrackSearchService
    {
        /// <summary>
        /// Finds Track by title, artist and duration.
        /// </summary>
        /// <returns>{Found, Message, ArtistId, AlbumId, TrackId}</returns>
        TrackSearchResult FindTrack(string artist, string title, string album);

        /// <summary>
        /// Finds Track by URI
        /// </summary>
        /// <returns>TrackId or 0 if not found</returns>
        int FindTrack(string uri);
    }
}