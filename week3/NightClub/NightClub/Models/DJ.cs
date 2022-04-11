using NightClub.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Models
{
    public class DJ
    {
        public DJ(int count)
        {
            CountOfTracks = count;
        }

        private int CountOfTracks { get; set; }

        public void CreatePlayList(TrackList trackList)
        {
            Random random = new Random();

            for (int i = 0; i < CountOfTracks; i++)
            {
                trackList.Tracks.Add(new Track() { MusicType = (TypeOfMusic)random.Next(0, 3) }); 
            }
        }

        public Track ChangeTrack(TrackList trackList)
        {

            if (trackList.Tracks.Count != 0)
            {
                var temp = trackList.Tracks.First();

                trackList.Tracks.Remove(trackList.Tracks.First());

                return temp;
            }

            return null;
        }
    }
}
