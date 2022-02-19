using PubgTournament.Models;



namespace PubgTournament.Models
{
    public class Player : Document{
       
        public string PlayerName { get; set; }
        public int Kills { get; set; }
        public bool IsAlive { get; set; }
        public bool IsPlaying { get; set; }
        public bool Domination { get; set; }
}
}
