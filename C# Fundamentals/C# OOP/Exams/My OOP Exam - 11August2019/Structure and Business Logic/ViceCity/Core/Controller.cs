namespace ViceCity.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ViceCity.Core.Contracts;
    using ViceCity.Models.Guns;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;

    public class Controller : IController
    {
        private IList<IPlayer> players;
        private IList<IGun> guns;
        private INeighbourhood neighbourhood;
        private MainPlayer mainPlayer;

        public Controller()
        {
            this.players = new List<IPlayer>();
            this.guns = new List<IGun>();
            this.neighbourhood = new GangNeighbourhood();
            this.AddMainPlayer();
        }

        private void AddMainPlayer()
        {
            this.mainPlayer = new MainPlayer();
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;
            if (type == "Pistol")
            {
                gun = new Pistol(name);
                this.guns.Add(gun);

                return $"Successfully added {name} of type: {type}";
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name);
                this.guns.Add(gun);

                return $"Successfully added {name} of type: {type}";
            }
            else
            {
                return "Invalid gun type!";
            }
        }

        public string AddGunToPlayer(string name)
        {
            var gun = this.guns.FirstOrDefault();
            if (gun == null)
            {
                return "There are no guns in the queue!";
            }
            if (name == "Vercetti")
            {
                mainPlayer.GunRepository.Add(gun);
                this.guns.RemoveAt(0);

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            var player = this.players.FirstOrDefault(x => x.Name == name);
            if (player == null)
            {
                return "Civil player with that name doesn't exists!";
            }

            player.GunRepository.Add(gun);
            this.guns.RemoveAt(0);
            return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
        }

        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);
            this.players.Add(player);

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            var sb = new StringBuilder();
            var mainPlayerPoint = mainPlayer.LifePoints;
            var civilPlayersPoint = new Dictionary<string, int>();
            foreach (var pl in this.players)
            {
                civilPlayersPoint[pl.Name] = pl.LifePoints;
            }
            this.neighbourhood.Action(mainPlayer, this.players);

            if (mainPlayerPoint != mainPlayer.LifePoints || civilPlayersPoint.Count != this.players.Count)
            {
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {civilPlayersPoint.Count - this.players.Count} players!");
                sb.AppendLine($"Left Civil Players: {this.players.Count}!");
                return sb.ToString().TrimEnd();
            }
            foreach (var item in this.players)
            {
                if (!civilPlayersPoint.ContainsKey(item.Name))
                {
                    sb.AppendLine("A fight happened:");
                    sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
                    sb.AppendLine($"Tommy has killed: {civilPlayersPoint.Count - this.players.Count} players!");
                    sb.AppendLine($"Left Civil Players: {this.players.Count}!");
                    return sb.ToString().TrimEnd();
                }

                if (civilPlayersPoint[item.Name] != item.LifePoints)
                {
                    sb.AppendLine("A fight happened:");
                    sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
                    sb.AppendLine($"Tommy has killed: {civilPlayersPoint.Count - this.players.Count} players!");
                    sb.AppendLine($"Left Civil Players: {this.players.Count}!");
                    return sb.ToString().TrimEnd();
                }
            }

            return "Everything is okay!";
        }
    }
}
