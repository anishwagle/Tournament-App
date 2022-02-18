using System.Collections.Generic;
using System;
namespace PubgTournament.Models
{
    public class Team : Document{
        public string FullName { get; set; }
        public byte[] TeamLogo { get; set; }
        public string ShortName { get; set; }
        public List<Player> Players { get; set; }
        public int Kills { get; set; }
        public bool IsEliminated { get; set; }
        public int EliminationOrder { get; set; }
    }
}