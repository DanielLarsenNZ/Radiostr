using System.Threading.Tasks;

namespace Radiostr.SpotifyWebApi
{
    /// <summary>
    /// Defines a wrapper for the Spotify Web Playlists API.
    /// </summary>
    public interface IPlaylistsApi
    {
        /// <summary>
        /// Get a list of a user's playlists.
        /// </summary>
        /// <returns>The JSON result deserialized to object (as dynamic).</returns>
        Task<dynamic> GetPlaylists(string username);

        /// <summary>
        /// Get a list of a user's playlists.
        /// </summary>
        /// <returns>The JSON result deserialized to <see cref="T"/>.</returns>
        Task<T> GetPlaylists<T>(string username);

        Task<dynamic> GetPlaylist(string username, string playlistId);
        Task<T> GetPlaylist<T>(string username, string playlistId);

        Task<dynamic> GetTracks(string username, string playlistId);
        Task<T> GetTracks<T>(string username, string playlistId);

        Task<dynamic> CreatePlaylist(string username, string name, bool isPublic);
        Task<T> CreatePlaylist<T>(string username, string name, bool isPublic);

        Task AddTracks(string username, string playlistId, string[] uris);
    }
}
