using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsAndVenues
{
    class Bracket
    {
        public List<Team> teams { get; set; }
        public bool IsDirty { get; set; }

        public Bracket(List<Team> tList)
        {
            teams = tList;
            IsDirty = false;
        }

        public Bracket()
        {
            teams = new List<Team>();
            IsDirty = false;
        }



        
    }
}
