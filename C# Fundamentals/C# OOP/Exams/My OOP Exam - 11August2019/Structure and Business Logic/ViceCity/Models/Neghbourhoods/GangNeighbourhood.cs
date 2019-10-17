namespace ViceCity.Models.Neghbourhoods
{
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            MainPlayerAttacks(mainPlayer, civilPlayers);
            CivilPlayersAttack(mainPlayer, civilPlayers);
        }

        private static void CivilPlayersAttack(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            var counter = 0;
            var currentplayer = civilPlayers.FirstOrDefault();
            while (true)
            {
                if (currentplayer == null)
                {
                    return;
                }

                var currentGun = currentplayer.GunRepository.Models.FirstOrDefault();
                if (currentGun == null)
                {
                    counter++;
                    currentplayer = civilPlayers.Skip(counter).FirstOrDefault();
                }

                var bulletsShot = currentGun.Fire();
                mainPlayer.TakeLifePoints(bulletsShot);
                if (!currentGun.CanFire)
                {
                    mainPlayer.GunRepository.Remove(currentGun);
                }

                if (!mainPlayer.IsAlive)
                {
                    return;
                }
            }
        }

        private static void MainPlayerAttacks(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (true)
            {
                var currentGun = mainPlayer.GunRepository.Models.FirstOrDefault();
                if (currentGun == null)
                {
                    return;
                }

                var currentplayer = civilPlayers.FirstOrDefault();
                if (currentplayer == null)
                {
                    return;
                }

                var bulletsShot = currentGun.Fire();
                currentplayer.TakeLifePoints(bulletsShot);
                if (!currentGun.CanFire)
                {
                    mainPlayer.GunRepository.Remove(currentGun);
                }

                if (!currentplayer.IsAlive)
                {
                    civilPlayers.Remove(currentplayer);
                }
            }
        }
    }
}
