namespace MXGP.Models.Riders
{
    using MXGP.Models.Riders.Contracts;

    public class RiderFactory : IRiderFactory
    {
        public IRider CreateInstance(string name)
        {
            IRider rider = new Rider(name);

            return rider;
        }
    }
}
