namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int Damage_Points = 120;
        private const int Health_Points = 5;

        public TrapCard(string name) : base(name, Damage_Points, Health_Points)
        {
        }
    }
}
