using System.Collections.Generic;
namespace PubgTournament.Models
{
    public class Group :Document{
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
    }
    
}