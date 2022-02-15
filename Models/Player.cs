using PubgTournament.Models;



namespace PubgTournament.Models
{
    public class Player : Document{
        // Player(){
        //     Kills=0;
        //     IsAlive=false;
        //     IsSub=false;
        // }
        public string Name { get; set; }
        public int Kills { get; set; }
        public bool IsAlive { get; set; }
        public bool IsSub { get; set; }
}
}
