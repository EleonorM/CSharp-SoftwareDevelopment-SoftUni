namespace CarManufacturer
{
    using System;
    using System.Text;
    using global::CarManufacturer;

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
                this.FuelQuantity -= distance * this.FuelConsumption/100;
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
}
