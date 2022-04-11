using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Models
{
    public class DancerList
    {
        public  List<Dancer> Dancers { get; private set; } = new List<Dancer>();
        public int CountOfDancers { get; private set; }

        public DancerList(int count)
        {
            CountOfDancers = count;
        }

        public void CreateDancers()
        {
            if (CountOfDancers < 0)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < CountOfDancers; i++)
            {
                Dancers.Add(new Dancer() {});
            }
        }
    }
}
