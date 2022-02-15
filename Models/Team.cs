using System.Collections.Generic;
namespace PubgTournament.Models
{
    public class Team : Document{
        public string Name { get; set; }
        public byte[] TeamLogo { get; set; }
        public List<Player> Players { get; set; }
        public int TeamKill { get; set; }
    }
}