using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketDemo
{
    class Bracket
    {
        public List<Team> Teams { get; private set; }
        public Bracket()
        {
            Teams = new List<Team>();
        }

        public Bracket(List<Team> teams)
        {
            Teams = teams;
        }
    }
}
