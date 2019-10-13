namespace MXGP.Models.Factory
{
    using MXGP.Models.Motorcycles.Contracts;

    public interface IMotorcycleFactory
    {
        IMotorcycle CreateInstance(string type, string model, int horsePower);
    }
}
