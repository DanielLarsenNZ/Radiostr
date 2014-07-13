using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Radiostr.Web.Http;
using Radiostr.Web.Models;

namespace Radiostr.Web.Services
{
    public class SpotifyService
    {
        private readonly IHttpClient _httpClient;

        public SpotifyService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SpotifyPlaylist>> GetPlaylists(string spotifyUserId)
        {
            const string urlFormat = "https://api.spotify.com/v1/users/{0}/playlists?limit=50";

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