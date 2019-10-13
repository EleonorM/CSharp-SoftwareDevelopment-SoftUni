namespace _04._Raw_Data
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
                var engineSpeed = int.Parse(input[1]);
                var enginePower = int.Parse(input[2]);
                var cargoWeight = int.Parse(input[3]);
                var cargoType = input[4];
                var car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType);
                cars.Add(car);
            }

            var action = Console.ReadLine();

            foreach (var car in cars)
            {
                if (action == "fragile" && car.Cargo.Type == "fragile" && car.Cargo.Weight < 1000)
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

    public class Car
    {
        public string Model;
        public Engine Engine;
        public Cargo Cargo;

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType)
        {
            Model = model;
            Engine = new Engine();
            Engine.Speed = engineSpeed;
            Engine.Power = enginePower;
            Cargo = new Cargo();
            Cargo.Weight = cargoWeight;
            Cargo.Type = cargoType;
        }
    }

    public class Engine
    {
        public int Speed;
        public int Power;
    }

    public class Cargo
    {
        public int Weight;
        public string Type;
    }
}
