namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionIncreasment = 1.6;
        private const double RefuelingCoefficient = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + FuelConsumptionIncreasment, tankCapacity)
        {
        }

        public override void Refuel(double litersOfFuel)
        {
            base.Refuel(litersOfFuel);
            this.FuelQuantity -= (1 - RefuelingCoefficient) * litersOfFuel;
        }
    }
}
