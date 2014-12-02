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
        public List<Team[]> matchups { get; set; }

        public Bracket(List<Team> tList)
        {
            teams = tList;
            IsDirty = false;
            matchups = new List<Team[]>();

            var seedSortedList =
                (from t in teams
                select t).OrderBy(x => x.Seed);
            List<Team> sorted = seedSortedList.ToList();
            for(int i = 0; i < sorted.Count - 1; i +=2)
            {
                matchups.Add(new Team[] { sorted.ElementAt(i), sorted.ElementAt(i + 1) });
            }
        }

        public Bracket()
        {
            teams = new List<Team>();
            IsDirty = false;
        }







        
    }
}
