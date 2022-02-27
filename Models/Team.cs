using System.Collections.Generic;
using System;
namespace PubgTournament.Models
{
    public class Team : Document{
        public string FullName { get; set; }

        public string TeamLogo { get; set; }
        public string ShortName { get; set; }
        public List<Player> Players { get; set; }
        public int Kills { get; set; }
        public bool IsEliminated { get; set; }
        public bool IsEliminatedMsg { get; set; }
        public int EliminationOrder { get; set; }
    }
}