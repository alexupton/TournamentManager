using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsAndVenues
{
    class Team
    {
        public string Name{ get; set;}
        public int Seed {get; set;}
        public int Wins{get; private set;}
        public bool isTop { get; set; }
        public Team(string name, int seed, int wins)
        {
            Name = name;
            Seed = seed;
            Wins = wins;
        }

        public void Win()
        {
            Wins++;
        }

        public void Unwin()
        {
            if (Wins > 0)
                Wins--;
        }

    }
}
