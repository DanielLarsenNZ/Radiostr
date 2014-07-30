using System;

namespace Radiostr.Model
{
    public class PlaylistModel
    {
        public string ServiceName { get; set; }
        public string[] Uris { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string OwnerUserId { get; set; }
        public int TrackCount { get; set; }
        public bool Add { get; set; }
        public bool Loading { get; set; }

        /// <summary>
        /// The Date and Time that this data was requested from the Spotify API.
        /// </summary>
        public DateTime RequestDateTime { get; set; }
    }
}