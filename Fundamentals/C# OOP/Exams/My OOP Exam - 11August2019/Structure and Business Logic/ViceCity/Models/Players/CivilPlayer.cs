namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player
    {
        private const int InitiaLifePoints = 50;

        public CivilPlayer(string name) 
            : base(name, InitiaLifePoints)
        {
        }
    }
}
