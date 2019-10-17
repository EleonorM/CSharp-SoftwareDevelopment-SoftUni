namespace _03._Speed_Racing
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var carsNumber = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < carsNumber; i++)
            {
                var car = new Car();
                var input = Console.ReadLine().Split();
                car.Model = input[0];
                car.FuelAmount = int.Parse(input[1]);
                car.FuelConsumptionPerKm = double.Parse(input[2]);
                car.TraveledDistance = 0;
                cars.Add(car);
            }

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }
                var carModel = input[1];
                var km = int.Parse(input[2]);
                foreach (var car in cars)
                {
                    if (car.Model == carModel)
                    {
                        car.CanDrive(km);
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }

    class Car
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
