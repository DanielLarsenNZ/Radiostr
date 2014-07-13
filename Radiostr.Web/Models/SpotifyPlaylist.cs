using System;

namespace Radiostr.Web.Models
{
    public class SpotifyPlaylist
    {
        public string[] Uris { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string OwnerUserId { get; set; }
        public int TrackCount { get; set; }

        /// <summary>
        /// The Date and Time that this data was requested from the Spotify API.
        /// </summary>
        public DateTime RequestDateTime { get; set; }
    }
}