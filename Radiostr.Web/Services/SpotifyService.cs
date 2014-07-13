using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Radiostr.Web.Http;
using Radiostr.Web.Models;

namespace Radiostr.Web.Services
{
    /// <summary>
    /// A service for getting metadata from the Spotify Web API.
    /// </summary>
    public class SpotifyService
    {
        private readonly IHttpClient _httpClient;

        public SpotifyService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Gets a list of all public Playlists subscribed to by a Spotify user for a given <see cref="spotifyUserId"/>.
        /// </summary>
        /// <param name="spotifyUserId">Spotify User Id. See https://developer.spotify.com/web-api/user-guide/#spotify-uris-and-ids. </param>
        /// <returns>An (awaitable Task) IEnumerable of <see cref="SpotifyPlaylist"/>.</returns>
        public async Task<IEnumerable<SpotifyPlaylist>> GetPlaylists(string spotifyUserId)
        {
            const string urlFormat = "https://api.spotify.com/v1/users/{0}/playlists?limit=50";

            if (string.IsNullOrEmpty(spotifyUserId)) throw new ArgumentNullException("spotifyUserId");

            string json = await _httpClient.GetAsync(string.Format(urlFormat, spotifyUserId));

            dynamic response = JsonConvert.DeserializeObject(json);

            var items = new List<dynamic>(response.items);

            var playlists = new List<SpotifyPlaylist>();
            foreach (var playlist in items)
            {
                playlists.Add(new SpotifyPlaylist
                {
                    Uris = new string[] {playlist.href},
                    Id = playlist.id,
                    Name = playlist.name,
                    OwnerUserId = playlist.owner.id,
                    TrackCount = playlist.tracks.total,
                    RequestDateTime = DateTime.Now
                });
            }

            return playlists;
        }
    }
}