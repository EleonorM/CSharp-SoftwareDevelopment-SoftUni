namespace _06._Vehicle_Catalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public class Truck
        {
            public string Brand { get; set; }

            public string Color { get; set; }

            public double HorsePower { get; set; }
        }
        public class Car
        {
            public string Brand { get; set; }

            public string Color { get; set; }

            public double HorsePower { get; set; }
        }
        public class Catalouge
        {
            public List<Truck> Trucks { get; set; }

            public List<Car> Cars { get; set; }
        }
        public static void Main()
        {
            var catalouge = new Catalouge();
            catalouge.Cars = new List<Car>();
            catalouge.Trucks = new List<Truck>();

            var sumHpCars = 0.0;
            var sumHpTrucks = 0.0;
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                List<string> veichle = input.Split().ToList();
                var type = veichle[0].ToLower();
                var brand = veichle[1];
                var color = veichle[2];
                var hPower = int.Parse(veichle[3]);

                if (type == "car")
                {
                    var car = new Car();
                    car.Brand = brand;
                    car.Color = color;
                    car.HorsePower = hPower;
                    sumHpCars += hPower;
                    catalouge.Cars.Add(car);
                }
                else if (type == "truck")
                {
                    var truck = new Truck();
                    truck.Brand = brand;
                    truck.Color = color;
                    truck.HorsePower = hPower;
                    sumHpTrucks += hPower;
                    catalouge.Trucks.Add(truck);
                }
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Close the Catalogue")
                {
                    break;
                }

                foreach (var car in catalouge.Cars)
                {
                    if (car.Brand == input)
                    {
                        Console.WriteLine("Type: Car");
                        Console.WriteLine($"Model: {car.Brand}");
                        Console.WriteLine($"Color: {car.Color}");
                        Console.WriteLine($"Horsepower: {car.HorsePower}");
                    }
                }

                foreach (var truck in catalouge.Trucks)
                {
                    if (truck.Brand == input)
                    {
                        Console.WriteLine("Type: Truck");
                        Console.WriteLine($"Model: {truck.Brand}");
                        Console.WriteLine($"Color: {truck.Color}");
                        Console.WriteLine($"Horsepower: {truck.HorsePower}");
                    }
                }
            }

            if (catalouge.Cars.Count != 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {sumHpCars / catalouge.Cars.Count / 1.0:f2}.");
            }
            else Console.WriteLine($"Cars have average horsepower of: 0.00.");

            if (catalouge.Trucks.Count != 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {sumHpTrucks / catalouge.Trucks.Count / 1.0:f2}.");
            }
            else Console.WriteLine($"Trucks have average horsepower of: 0.00.");
        }
    }
}
