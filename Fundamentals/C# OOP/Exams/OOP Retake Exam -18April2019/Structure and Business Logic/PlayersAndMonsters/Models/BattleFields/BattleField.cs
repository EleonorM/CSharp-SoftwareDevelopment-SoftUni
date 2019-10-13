namespace PlayersAndMonsters.Models.BattleFields
{
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Linq;

    public class BattleField : IBattleField
    {
        private const int DefaultDamagePointsForBeginner = 30;
        private const int DefaultHealthPointsForBeginner = 40;

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (AreDead(attackPlayer, enemyPlayer))
            {
                throw new ArgumentException("Player is dead!");
            }

            AddPointsIfBeginner(attackPlayer);
            AddPointsIfBeginner(enemyPlayer);

            foreach (var card in attackPlayer.CardRepository.Cards)
            {
                attackPlayer.Health += card.HealthPoints;
            }

            foreach (var card in enemyPlayer.CardRepository.Cards)
            {
                enemyPlayer.Health += card.HealthPoints;
            }

            while (true)
            {
                var attackPlayerTotalDamagePoints = attackPlayer.CardRepository.Cards.Sum(d => d.DamagePoints);
                enemyPlayer.TakeDamage(attackPlayerTotalDamagePoints);

                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                var enemyPlayerTotalDamagePoints = enemyPlayer.CardRepository.Cards.Sum(d => d.DamagePoints);
                attackPlayer.TakeDamage(enemyPlayerTotalDamagePoints);

                if (attackPlayer.Health == 0)
                {
                    break;
                }
            }
        }

        private static bool AreDead(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            return attackPlayer.IsDead || enemyPlayer.IsDead;
        }

        private void AddPointsIfBeginner(IPlayer player)
        {
            if (player is Beginner)
            {
                player.Health += DefaultHealthPointsForBeginner;
                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += DefaultDamagePointsForBeginner;
                }
            }
        }
    }
}
