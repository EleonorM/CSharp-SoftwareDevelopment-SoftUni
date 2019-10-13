namespace MXGP.Models.Races.Factory
{
    using MXGP.Models.Races.Contracts;

    public class RaceFactory : IRaceFactory
    {
        public IRace CreateInstance(string name, int laps)
        {
            IRace race = new Race(name, laps);
            return race;
        }
    }
}
