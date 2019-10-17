namespace MXGP.Models.Factory
{
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Motorcycles.Contracts;

    public class MotorcycleFactory : IMotorcycleFactory
    {
        public IMotorcycle CreateInstance(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = null;

            switch (type)
            {
                case "Speed":
                    motorcycle = new SpeedMotorcycle(model, horsePower);
                    break;
                case "Power":
                    motorcycle = new PowerMotorcycle(model, horsePower);
                    break;
                default:
                    break;
            }

            return motorcycle;
        }
    }
}
