namespace _01.Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption  { get; }

        bool Drive(double km);

        void Refuel (double litersOfFuel);
    }
}
