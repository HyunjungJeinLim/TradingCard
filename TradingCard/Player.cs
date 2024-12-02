namespace TradingCard
{
    public class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
        public string PhotoUrl { get; set; }
        public int GamesPlayed { get; set; }
        public int HomeRuns { get; set; }
        public int RBIs { get; set; }
        public double BattingAverage { get; set; }

        public Player(string name, string team, string photoUrl, int gamesPlayed, int homeRuns, int rbis, double battingAverage)
        {
            Name = name;
            Team = team;
            PhotoUrl = photoUrl;
            GamesPlayed = gamesPlayed;
            HomeRuns = homeRuns;
            RBIs = rbis;
            BattingAverage = battingAverage;
        }
    }
}
