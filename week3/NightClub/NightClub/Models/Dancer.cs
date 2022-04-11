using NightClub.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NightClub.Models
{
    public class Dancer
    {
        public string DanceMove(Track track)
        {
            if (track == null)
            {
                Environment.Exit(0);
            }

            if (track.MusicType == TypeOfMusic.HardBass)
            {
                //Console.WriteLine("Elbow for Hardbass");
                return "Elbow for Hardbass";
            }
            else if(track.MusicType == TypeOfMusic.Latino)
            {
                //Console.WriteLine("Hips for Latino");
                return "Hips for Latino";
            }
            else if(track.MusicType == TypeOfMusic.Rock)
            {
                //Console.WriteLine("Head for Rock");
                return "Head for Rock";
            }
            else
            {
                //Console.WriteLine("We dont know this type of music");
                return "We dont know this type of music";
            }
        }
    }
}
