using System;
using System.ComponentModel.DataAnnotations;

namespace Radiostr.Model
{
    public class TrackModel : RadiostrTableEntity 
    {
        public TrackModel()
        {
        }

        /// <summary>
        /// Creates a new TrackModel.
        /// </summary>
        public TrackModel(string title, ArtistModel artist, int duration)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException("title");
            if (artist == null) throw new ArgumentNullException("artist");
            if (duration < 1000) throw new ArgumentOutOfRangeException("duration", "duration cannot be less that 1000ms");
            if (string.IsNullOrEmpty(artist.Name)) throw new ArgumentException("artist.Name is required.");

            Title = title;
            Artist = artist;
            Duration = duration;

            Init();
        }

        /// <summary>
        /// Derives a Partition Key based on the properties of this entity.
        /// </summary>
        internal override string DerivePartitionKey()
        {
            return DerivePartitionKey(this);
        }

        /// <summary>
        /// Derives a Partition Key based on the properties of track.
        /// </summary>
        internal static string DerivePartitionKey(TrackModel track)
        {
            if (track == null) throw new ArgumentNullException("track");
            if (track.Artist == null) throw new ArgumentException("track.Artist is required");
            if (string.IsNullOrEmpty(track.Artist.Name)) throw new ArgumentException("track.Artist.Name is required");
            
            return "Artists_" + track.Artist.Name.Trim().Substring(0,1).ToUpperInvariant();
        }

        [Required]
        [MaxLength(400)]
        public string Title { get; set; }

        /// <summary>
        /// The Main Artist.
        /// </summary>
        [Required]
        public ArtistModel Artist { get; set; }

        /// <summary>
        /// All Artists listed on the Track.
        /// </summary>
        public ArtistModel[] Artists { get; set; }
        
        public AlbumModel Album { get; set; }

        /// <summary>
        /// Track duration in milliseconds
        /// </summary>
        [Required]
        public int Duration { get; set; }
        
        public string[] Uri { get; set; }

        public string[] Tags { get; set; }

        public override string ToString()
        {
            return string.Format("(TrackModel Title = {0}, Artist = {1}, Album = {2}, Duration = {3}, Uri = {4}, Tags = {5}, Entity = {6})",
                Title, Artist, Album, Duration, Uri, Tags, base.ToString());
        }
    }
}