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
        DJ dj = new DJ(5);
        ManualResetEvent resetEvent = new ManualResetEvent(false);

        public void BeginParty()
        {
            dj.CreatePlayList(trackList);
            dancerList.CreateDancers();

            Thread trackthread = new Thread(() => PlayTrack());
            trackthread.Start();

            foreach (var dancer in dancerList.Dancers)
            {
                Thread dancerThread = new Thread(() => Dance(dancer));
                dancerThread.Start();
            }
        }

        void Dance(Dancer dancer)
        {
            while (true)
            {
                if (trackList.isTheEnd)
                {
                    break;
                }

                resetEvent.WaitOne();

                Console.WriteLine(dancer.DanceMove(currentTrack));
                Thread.Sleep(100);
            }
        }

        void PlayTrack()
        {
            while (trackList.Tracks.Count > 0)
            {
                currentTrack = dj.ChangeTrack(trackList);

                Console.WriteLine(currentTrack.MusicType);

                Thread.Sleep(1000);

                resetEvent.Set();

                Thread.Sleep(5000);

                resetEvent.Reset();
            }

            trackList.isTheEnd = true;
            Thread.Sleep(1000);
        }
    }
}
