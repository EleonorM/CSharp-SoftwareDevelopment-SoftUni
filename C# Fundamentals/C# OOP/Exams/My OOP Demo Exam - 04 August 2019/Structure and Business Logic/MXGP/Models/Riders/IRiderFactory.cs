namespace MXGP.Models.Riders
{
    using MXGP.Models.Riders.Contracts;

    public interface IRiderFactory
    {
        IRider CreateInstance(string name);
    }
}
