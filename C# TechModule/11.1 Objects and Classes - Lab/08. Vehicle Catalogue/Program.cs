namespace _08.Vehicle_Catalogue
{
using System;
using System.Collections.Generic;
using System.Linq;

    public class Program
    {
        public class Truck
        {
            public string Brand { get; set; }

            public string Model { get; set; }

            public string Weight { get; set; }
        }
        public class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public string HorsePower { get; set; }
        }
        public class Catalouge
        {
            public List<Truck> Trucks { get; set; }

            public List<Car> Cars { get; set; }
        }

        private static void Main(string[] args)
        {
            List<Catalouge> catalouges = new List<Catalouge>();
            var catalouge = new Catalouge();
            catalouge.Cars = new List<Car>();
            catalouge.Trucks = new List<Truck>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                List<string> veichle = input.Split('/').ToList();
                var type = veichle[0];
                var brand = veichle[1];
                var model = veichle[2];
                var hpOrWeight = veichle[3];

                if (type == "Car")
                {
                    var car = new Car();
                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = hpOrWeight;
                    catalouge.Cars.Add(car);
                }
                else
                {
                    var truck = new Truck();
                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = hpOrWeight;
                    catalouge.Trucks.Add(truck);
                }
            }

            catalouge.Cars = catalouge.Cars
                .OrderBy(br => br.Brand)
                .ToList();
            catalouge.Trucks = catalouge.Trucks
                .OrderBy(br => br.Brand)
                .ToList();
            catalouges.Add(catalouge);

            if (catalouge.Cars.Count > 0)
            {
                Console.WriteLine($"Cars:");
                foreach (var item in catalouge.Cars)
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.HorsePower}hp");
                }
            }

            if (catalouge.Trucks.Count > 0)
            {
                Console.WriteLine($"Trucks:");
                foreach (var item in catalouge.Trucks)
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.Weight}kg");
                }
            }
        }
    }
}
