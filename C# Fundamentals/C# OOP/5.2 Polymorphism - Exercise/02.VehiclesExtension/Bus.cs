namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public bool DriveWithPeople(double km)
        {
            var fuelToUse = km * (FuelConsumption + 1.4);
            if (fuelToUse <= FuelQuantity)
            {
                base.FuelQuantity -= fuelToUse;
                return true;
            }

            return false;
        }
    }
}
