using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Radiostr.SpotifyWebApi.Http;

namespace Radiostr.SpotifyWebApi
{
    public class PlaylistsApi : IPlaylistsApi
    {
        internal const string BaseUrl = "https://api.spotify.com/v1";
        private readonly IHttpClient _http;
        private readonly IAuthorizationApi _auth;

        public PlaylistsApi(IHttpClient httpClient, IAuthorizationApi authorizationApi)
        {
            _http = httpClient;
            _auth = authorizationApi;
        }

        /// <summary>
        /// Get a list of a user's playlists.
        /// </summary>
        /// <returns>The JSON result deserialized to object (as dynamic).</returns>
        public async Task<dynamic> GetPlaylists(string username)
        {
            return await GetPlaylists<dynamic>(username);
        }

        /// <summary>
        /// Get a list of a user's playlists.
        /// </summary>
        /// <returns>The JSON result deserialized to <see cref="T"/>.</returns>
        public async Task<T> GetPlaylists<T>(string username)
        {
            const string urlFormat = BaseUrl + "/users/{0}/playlists";

            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException("username");

            string json = await _http.Get(string.Format(urlFormat, Uri.EscapeDataString(username)),
                new AuthenticationHeaderValue("Bearer", await _auth.GetAccessToken()));
            var playlists = JsonConvert.DeserializeObject<T>(json);
            Trace.TraceInformation("Got Playlists: " + playlists);

            return playlists;
        }

        public async Task<dynamic> GetPlaylist(string username, string playlistId)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetPlaylist<T>(string username, string playlistId)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GetTracks(string username, string playlistId)
        {
            return await GetTracks<dynamic>(username, playlistId);
        }

        /// <summary>
        /// Get full details of the tracks of a playlist owned by a Spotify user.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="username">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <returns></returns>
        public async Task<T> GetTracks<T>(string username, string playlistId)
        {
            // /users/{user_id}/playlists/{playlist_id}/tracks
            const string urlFormat = BaseUrl + "/users/{0}/playlists/{1}/tracks";

            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException("username");
            if (string.IsNullOrEmpty(playlistId)) throw new ArgumentNullException("playlistId");

            string json =
                await
                    _http.Get(
                        string.Format(urlFormat, Uri.EscapeDataString(username), Uri.EscapeDataString(playlistId)),
                        new AuthenticationHeaderValue("Bearer", await _auth.GetAccessToken()));
            var tracks = JsonConvert.DeserializeObject<T>(json);
            Trace.TraceInformation("Got Tracks: " + tracks);

            return tracks;
        }

        public async Task<dynamic> CreatePlaylist(string username, string name, bool isPublic)
        {
            throw new NotImplementedException();
        }

        public async Task<T> CreatePlaylist<T>(string username, string name, bool isPublic)
        {
            throw new NotImplementedException();
        }

        public async Task AddTracks(string username, string playlistId, string[] uris)
        {
            throw new NotImplementedException();
        }
    }
}
