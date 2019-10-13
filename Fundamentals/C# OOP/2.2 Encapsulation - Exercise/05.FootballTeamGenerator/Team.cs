namespace _05.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private List<Player> players;
        private int rating;

        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();
        }

        public string Name { get; set; }

        public int Rating
        {
            get
            {
                if (players.Count != 0)
                {
                    return (int)Math.Round(this.players.Average(x => x.SkillLevel),0);
                }
                else
                    return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            if (this.players.FirstOrDefault(x => x.Name == name) != null)
            {
                this.players.Remove(this.players.FirstOrDefault(x => x.Name == name));
            }
            else
            {
                throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            }
        }

    }
}
