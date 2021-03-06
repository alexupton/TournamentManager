﻿using System;
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

            //LINQ to sort list by seed value
            var seedSortedList =
                (from t in teams
                select t).OrderBy(x => x.Seed);
            List<Team> sorted = seedSortedList.ToList();

            //use the sorted list to pair every team with its nearest seed neighbor
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

        public void UpdateBracket(Team updatedTeam, int teamIndex)
        {
            teams.RemoveAt(teamIndex);
            teams.Insert(teamIndex, updatedTeam);
        }







        
    }
}
