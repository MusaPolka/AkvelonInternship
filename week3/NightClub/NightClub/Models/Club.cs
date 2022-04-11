using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NightClub.Models
{
    public class Club
    {
        TrackList trackList = new TrackList();
        DancerList dancerList = new DancerList(10);
        Track currentTrack = new Track();
        DJ dj = new DJ(10);

        public void BeginParty()
        {
            dj.CreatePlayList(trackList);
            dancerList.CreateDancers();

            while (true)
            {
                Thread trackThread = new Thread(() => PlayTrack());               
                trackThread.Start();


                if (currentTrack == null)
                {
                    break;
                }

                Thread dancerThread = new Thread(() => Dance(currentTrack));
                dancerThread.Start();

                Thread.Sleep(10000);
                
            }
        }

        void Dance(Track track)
        {
            if (currentTrack != null)
                Console.WriteLine($"New track is {currentTrack.MusicType}");

            while (true)
            {

                foreach (var dancer in dancerList.Dancers)
                {
                    Console.WriteLine(dancer.DanceMove(track));
                    Thread.Sleep(100);

                    if (trackList.isChanged)
                    {
                        break;
                    }
                }
                if (trackList.isChanged)
                {
                    trackList.isChanged = false;
                    break;
                }
            }
        }

        void PlayTrack()
        {
            currentTrack = dj.ChangeTrack(trackList);

            Thread.Sleep(10000);

            trackList.isChanged = true; 
        }
    }
}
