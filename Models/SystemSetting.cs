using System.Collections.Generic;
namespace PubgTournament.Models
{
    public class SystemSetting :Document{
        public string AliveCounterBgImage { get; set; }
        public string DominationBgImage { get; set; }
        public string EliminatedBgImage { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string AliveColor { get; set; }
        public string DeadColor { get; set; }
    }
    
}