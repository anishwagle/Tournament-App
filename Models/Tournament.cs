using System.Collections.Generic;
namespace PubgTournament.Models
{
    public class Tournament :Document{
        public string Name { get; set; }
        public List<Match> Matches { get; set; }
    }
    
}