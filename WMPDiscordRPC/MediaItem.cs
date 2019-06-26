using System;

namespace WMPDiscordRPC
{
    internal class MediaItem
    {
        public MediaItem()
        {
            StartedPlaying = DateTime.Now;
        }

        public string TrackName { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public double TrackLength { get; set; }
        public DateTime StartedPlaying { get; set; }
    }
}