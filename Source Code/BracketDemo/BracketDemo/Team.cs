using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketDemo
{
    class Team
    {
        public int Wins { get; set; }
        public string Name { get; set; }
        public int Seed { get; set; }

        public Team(string name, int seed, int wins)
        {
            Wins = wins;
            Name = name;
            Seed = seed;
        }
    }
}
