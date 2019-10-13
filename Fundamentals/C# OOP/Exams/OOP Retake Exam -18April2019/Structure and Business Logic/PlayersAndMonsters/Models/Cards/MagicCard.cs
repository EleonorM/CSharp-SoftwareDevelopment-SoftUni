namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int Damage_Points = 5;
        private const int Health_Points = 80;

        public MagicCard(string name) : base(name, Damage_Points, Health_Points)
        {
        }
    }
}
