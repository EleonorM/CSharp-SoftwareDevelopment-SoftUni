namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const string InitialName = "Tommy Vercetti";
        private const int InitiaLifePoints =100;

        public MainPlayer() 
            : base(InitialName, InitiaLifePoints)
        {
        }
    }
}
