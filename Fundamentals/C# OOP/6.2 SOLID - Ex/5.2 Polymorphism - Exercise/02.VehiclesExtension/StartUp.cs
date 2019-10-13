namespace _02.VehiclesExtension
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            var carInput = Console.ReadLine().Split();
            var car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));
            vehicles.Add(car);

            var truckInput = Console.ReadLine().Split();
            var truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));
            vehicles.Add(truck);

            var busInput = Console.ReadLine().Split();
            var bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3]));
            vehicles.Add(bus);

            var inputLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputLines; i++)
            {
                var actionInput = Console.ReadLine().Split();
                var action = actionInput[0];
                var vehicle = actionInput[1];
                if (action.Contains("Drive"))
                {
                    var km = double.Parse(actionInput[2]);
                    if (action == "Drive" && vehicle == "Bus")
                    {
                        if (((Bus)(vehicles[2])).DriveWithPeople(km))
                        {
                            Console.WriteLine($"{vehicles[2].GetType().Name} travelled {km} km");
                        }
                        else
                        {
                            Console.WriteLine($"{vehicles[2].GetType().Name} needs refueling");
                        }
                    }
                    else
                        DriveAction(vehicles, vehicle, km);
                }
                else if (action == "Refuel")
                {
                    var liters = double.Parse(actionInput[2]);

                    RefuleAction(vehicles, vehicle, liters);
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        private static void RefuleAction(List<Vehicle> vehicles, string vehicleType, double liters)
        {
            try
            {
                foreach (var vehicle in vehicles)
                {
                    if (vehicle.GetType().Name == vehicleType)
                    {
                        vehicle.Refuel(liters);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DriveAction(List<Vehicle> vehicles, string vehicleType, double km)
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle.GetType().Name == vehicleType)
                {
                    if (vehicle.Drive(km))
                    {
                        Console.WriteLine($"{vehicleType} travelled {km} km");
                    }
                    else
                    {
                        Console.WriteLine($"{vehicleType} needs refueling");
                    }
                }
            }
        }
    }
}
