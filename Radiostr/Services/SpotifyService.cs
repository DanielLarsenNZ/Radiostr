﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using Radiostr.Model;
using Radiostr.SpotifyWebApi;
using Radiostr.SpotifyWebApi.Cache;
using Radiostr.SpotifyWebApi.Http;

namespace Radiostr.Services
{
    /// <summary>
    /// A service for getting metadata from the Spotify Web API.
    /// </summary>
    public class SpotifyService
    {
        private readonly IPlaylistsApi _playlistsApi;
        private readonly ITrackImportService _trackImportService;


        public SpotifyService(IPlaylistsApi playlistsApi, ITrackImportService trackImportService)
        {
            if (playlistsApi == null) throw new ArgumentNullException("playlistsApi");
            if (trackImportService == null) throw new ArgumentNullException("trackImportService");

            _playlistsApi = playlistsApi;
            _trackImportService = trackImportService;
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

        public async Task ImportPlaylist(PlaylistImportModel importModel)
        {
            if (importModel == null) throw new ArgumentNullException("importModel");
            if (importModel.ServiceName != "spotify") throw new NotSupportedException(importModel.ServiceName + " is not a supported Service Name for SpotifyService.");
            
            var response = await _playlistsApi.GetTracks(importModel.UserId, importModel.PlaylistId);
            var items = new List<dynamic>(response.items);

            // Map to TrackImportModels
            var tracks = new List<TrackImportModel>();
            foreach (var item in items)
            {
                tracks.Add(new TrackImportModel
                {
                    Album = new AlbumImportModel { Name = item.track.album.name, Uri = item.track.album.uri },
                    Artist = new ArtistImportModel { Name = item.track.artists[0].name, Uri = item.track.artists[0].uri },
                    Duration = item.track.duration,
                    Uri = item.track.uri,
                    Title = item.track.name
                });
            }

            var trackImportModel = new TracksImportModel
            {
                LibraryId = importModel.LibraryId,
                StationId = int.Parse(importModel.StationId),
                Tracks = tracks.ToArray(),
                Tags = new[] { "spotify", importModel.UserId }    //TODO: https://github.com/DanielLarsenNZ/Radiostr/issues/9
            };

            await _trackImportService.ImportTracks(trackImportModel);

        }

        public static SpotifyService GetService()
        {
            var http = new RestHttpClient(new HttpClient());
            return
                new SpotifyService(new PlaylistsApi(http,
                    new ClientCredentialsAuthorizationApi(http, System.Configuration.ConfigurationManager.AppSettings,
                        new RuntimeMemoryCache(MemoryCache.Default))), TrackImportService.CreateTrackImportService());
        }

    }
}