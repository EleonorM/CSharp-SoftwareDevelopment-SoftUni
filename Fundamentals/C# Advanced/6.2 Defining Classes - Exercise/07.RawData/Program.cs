namespace _07.RawData
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
                var input = Console.ReadLine().Split();
                var model = input[0];
                var engineSpeed = double.Parse(input[1]);
                var enginePower = double.Parse(input[2]);
                var cargoWeight = double.Parse(input[3]);
                var cargoType = input[4];
                var tire1Pressure = double.Parse(input[5]);
                var tire1Age = double.Parse(input[6]);
                var tire2Pressure = double.Parse(input[7]);
                var tire2Age = double.Parse(input[8]);
                var tire3Pressure = double.Parse(input[9]);
                var tire3Age = double.Parse(input[10]);
                var tire4Pressure = double.Parse(input[11]);
                var tire4Age = double.Parse(input[12]);
                var car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType,tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure,tire3Age,tire4Pressure,tire4Age);
                cars.Add(car);
            }

            var action = Console.ReadLine();

            foreach (var car in cars)
            {
                if (action == "fragile" && car.Cargo.Type == "fragile" &&( car.Tire1.TirePressure < 1|| car.Tire2.TirePressure < 1 || car.Tire3.TirePressure < 1 || car.Tire4.TirePressure < 1))
                {
                    Console.WriteLine(car.Model);
                }
                else if (action == "flamable" && car.Cargo.Type == "flamable" && car.Engine.Power > 250)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
