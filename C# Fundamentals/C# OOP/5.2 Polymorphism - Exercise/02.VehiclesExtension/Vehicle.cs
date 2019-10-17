namespace _02.VehiclesExtension
{
using System;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;

            if (fuelQuantity > TankCapacity)
            {
                FuelQuantity = 0;
            }
            else
            {
                FuelQuantity = fuelQuantity;
            }

            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get;
            protected set;
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }

        public virtual bool Drive(double km)
        {
            var fuelToUse = km * FuelConsumption;
            if (fuelToUse <= FuelQuantity)
            {
                FuelQuantity -= fuelToUse;
                return true;
            }

            return false;
        }

        public virtual void Refuel(double litersOfFuel)
        {
            if (litersOfFuel <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (litersOfFuel + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {litersOfFuel} fuel in the tank");
            }

            FuelQuantity += litersOfFuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
