using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radiostr.Model;
using Radiostr.SpotifyWebApi;

namespace Radiostr.Services
{
    /// <summary>
    /// A service for getting metadata from the Spotify Web API.
    /// </summary>
    public class SpotifyService
    {
        private readonly IPlaylistsApi _playlistsApi;

        public SpotifyService(IPlaylistsApi playlistsApi)
        {
            _playlistsApi = playlistsApi;
        }

        /// <summary>
        /// Gets a list of all public Playlists subscribed to by a Spotify user for a given <see cref="spotifyUserId"/>.
        /// </summary>
        /// <param name="spotifyUserId">Spotify User Id. See https://developer.spotify.com/web-api/user-guide/#spotify-uris-and-ids. </param>
        /// <returns>An (awaitable Task) IEnumerable of <see cref="PlaylistModel"/>.</returns>
        public async Task<IEnumerable<PlaylistModel>> GetPlaylists(string spotifyUserId)
        {
            if (string.IsNullOrEmpty(spotifyUserId)) throw new ArgumentNullException("spotifyUserId");

            var response = await _playlistsApi.GetPlaylists(spotifyUserId);

            var items = new List<dynamic>(response.items);

            var playlists = new List<PlaylistModel>();
            foreach (var playlist in items)
            {
                playlists.Add(new PlaylistModel
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