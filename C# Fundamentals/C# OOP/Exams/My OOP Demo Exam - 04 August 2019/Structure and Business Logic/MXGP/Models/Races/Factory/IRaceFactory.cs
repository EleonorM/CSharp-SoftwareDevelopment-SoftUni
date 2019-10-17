namespace MXGP.Models.Races.Factory
{
    using MXGP.Models.Races.Contracts;

    public interface IRaceFactory
    {
        IRace CreateInstance(string name, int laps);
    }
}
