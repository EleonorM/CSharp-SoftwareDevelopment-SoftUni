namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using global::CarManufacturer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var tireCollection = new List<Tire[]>();
            

            while (true)
            {
                var tires = new Tire[4];
                var input = Console.ReadLine().Split();
                if (input[0] == "No")
                {
                    break;
                }

                var count = 0;

                for (int i = 0; i < 8; i = i + 2)
                {
                    var year = int.Parse(input[i]);
                    var pressure = double.Parse(input[i + 1]);
                    var tire = new Tire(year, pressure);
                    tires[count] = tire;
                    count++;
                }

                tireCollection.Add(tires);
            }

            var engines = new List<Engine>();

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "Engines")
                {
                    break;
                }

                var power = int.Parse(input[0]);
                var capacity = double.Parse(input[1]);
                var engine = new Engine(power, capacity);
                engines.Add(engine);
            }

            var cars = new List<Car>();

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "Show")
                {
                    break;
                }

                var make = input[0];
                var model = input[1];
                var year = int.Parse(input[2]);
                var fuelQuantity = double.Parse(input[3]);
                var fuelConsumption = double.Parse(input[4]);
                var engineIndex = int.Parse(input[5]);
                var tireIndex = int.Parse(input[6]);

                var car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tireCollection[tireIndex]);
                cars.Add(car);
            }

            var specialCars = cars
                .Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330 && (x.Tires.Sum(y => y.Pressure) < 10) && (x.Tires.Sum(y => y.Pressure) > 9))
                .ToList();

            foreach (var specialCar in specialCars)
            {
                specialCar.Drive(20);
                Console.WriteLine($"Make: {specialCar.Make}");
                Console.WriteLine($"Model: {specialCar.Model}");
                Console.WriteLine($"Year: {specialCar.Year}");
                Console.WriteLine($"HorsePowers: {specialCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
            }
        }

        public class Car
        {
            public Car()
            {
                this.Make = "VW";
                this.Model = "Golf";
                this.Year = 2025;
                this.FuelQuantity = 200;
                this.FuelConsumption = 10;
            }

            public Car(string make, string model, int year) : this()
            {
                this.Make = make;
                this.Model = model;
                this.Year = year;
            }

            public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
            {
                this.FuelConsumption = fuelConsumption;
                this.FuelQuantity = fuelQuantity;
            }

            public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engines, Tire[] tires) : this(make, model, year, fuelQuantity, fuelConsumption)
            {
                this.Engine = engines;
                this.Tires = tires;
            }

            public string Make { get; set; }

            public string Model { get; set; }

            public int Year { get; set; }

            public double FuelQuantity { get; set; }

            public double FuelConsumption { get; set; }

            public Engine Engine { get; set; }

            public Tire[] Tires { get; set; }

            public void Drive(double distance)
            {
                bool canContinue = this.FuelQuantity - (distance * this.FuelConsumption / 100) >= 0;

                if (canContinue)
                {
                    this.FuelQuantity -= distance * this.FuelConsumption / 100;
                }
                else
                {
                    Console.WriteLine("Not enough fuel to perform this trip!");
                }
            }

            public string WhoAmI()
            {
                StringBuilder result = new StringBuilder();

                result.AppendLine($"Make: {this.Make}");

                result.AppendLine($"Model: {this.Model}");

                result.AppendLine($"Year: {this.Year}");

                result.Append($"Fuel: {this.FuelQuantity:F2}L");

                return $"Make: { this.Make}\nModel: { this.Model}\nYear: { this.Year}\nFuel: { this.FuelQuantity:F2}L";
            }
        }

        public class Engine
        {
            public Engine(int power, double capacity)
            {
                this.HorsePower = power;
                this.CubicCapacity = capacity;
            }

            public int HorsePower { get; set; }

            public double CubicCapacity { get; set; }
        }

        public class Tire
        {
            public Tire(int year, double pressure)
            {
                this.Year = year;
                this.Pressure = pressure;
            }

            public int Year { get; set; }

            public double Pressure { get; set; }
        }
    }
}
