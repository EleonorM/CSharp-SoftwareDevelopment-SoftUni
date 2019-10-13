namespace _02.VehiclesExtension
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption  { get; }

        double TankCapacity { get; }

        bool Drive(double km);

        void Refuel (double litersOfFuel);
    }
}
