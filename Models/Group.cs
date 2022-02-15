using System.Collections.Generic;
namespace PubgTournament.Models
{
    public class Match :Document{
        public string Name { get; set; }
        public List<Group> Groups { get; set; }
    }
    
}