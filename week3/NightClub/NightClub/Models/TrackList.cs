using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NightClub.Models
{
    public class TrackList
    {
        public List<Track> Tracks { get;} = new List<Track>();
        public bool isTheEnd { get; set; } = false;

    }
}
