namespace _05.FootballTeamGenerator
{
    public class Player
    {
        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name { get; set; }

        public Stats Stats { get; set; }

        public double SkillLevel
        {
            get => (this.Stats.Endurance + this.Stats.Sprint + this.Stats.Dribble + this.Stats.Passing + this.Stats.Shooting) / 5.0;
        }
    }
}
