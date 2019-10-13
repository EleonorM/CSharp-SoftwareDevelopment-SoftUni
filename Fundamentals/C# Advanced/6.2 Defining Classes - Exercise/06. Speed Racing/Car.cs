namespace _06._Speed_Racing
{
    using System;

    public class Car
    {
        public string Model;
        public double FuelAmount;
        public double FuelConsumptionPerKm;
        public int TraveledDistance;

        public void CanDrive(int km)
        {
            if (FuelConsumptionPerKm * km <= FuelAmount)
            {
                FuelAmount -= FuelConsumptionPerKm * km;
                TraveledDistance += km;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
