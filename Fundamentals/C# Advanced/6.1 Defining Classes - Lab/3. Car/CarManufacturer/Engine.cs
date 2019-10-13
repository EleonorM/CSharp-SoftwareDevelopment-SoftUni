namespace CarManufacturer
{
    public class Engine
    {
        public Engine(int power, double capacity)
        {
            this.HorsePower = power;
            this.CubicCapacity = capacity;
        }

        public int HorsePower { get; set; }

        public double CubicCapacity { get; set; }
    }
}
