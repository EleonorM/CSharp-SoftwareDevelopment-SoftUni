namespace _08.CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var linesOfEngines = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();
            for (int i = 0; i < linesOfEngines; i++)
            {
                var engineProp = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var engine = new Engine();
                engine.Model = engineProp[0];
                engine.Power = double.Parse(engineProp[1]);
                try
                {
                    engine.Displacement = double.Parse(engineProp[2]);
                    try
                    {
                        engine.Efficiency = engineProp[3];
                    }
                    catch
                    {
                        engines.Add(engine);
                        continue;
                    }
                }
                catch
                {
                    try
                    {
                        engine.Efficiency = engineProp[2];
                    }
                    catch
                    {
                    }
                }

                engines.Add(engine);
            }

            var carsCount = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < carsCount; i++)
            {
                var carProp = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var car = new Car();
                car.Model = carProp[0];
                car.Engine = engines.Where(x => x.Model == carProp[1]).ToArray().FirstOrDefault();
                if (car.Engine == null)
                {
                    car.Engine.Model = carProp[1];
                }

                try
                {
                    car.Weight = double.Parse(carProp[2]);
                    try
                    {
                        car.Color = carProp[3];
                    }
                    catch
                    {
                        cars.Add(car);
                        continue;
                    }

                }
                catch
                {
                    try
                    {
                        car.Color = carProp[2];
                    }
                    catch
                    {
                    }
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                if (car.Engine == null)
                {
                    Console.WriteLine($"  {car.Engine.Model}:");
                    Console.WriteLine($"    Power: n/a");
                    Console.WriteLine($"    Displacement: n/a");
                    Console.WriteLine($"    Efficiency: n/a");
                    Console.WriteLine($"  Weight: n/a");
                    Console.WriteLine($"  Color: n/a");
                }

                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                if (car.Engine.Displacement != 0)
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }
                else
                {
                    Console.WriteLine($"    Displacement: n/a");
                }

                if (car.Engine.Efficiency != null)
                {
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: n/a");
                }

                if (car.Weight != 0)
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }
                else
                {
                    Console.WriteLine($"  Weight: n/a");
                }

                if (car.Color != null)
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }
                else
                {
                    Console.WriteLine($"  Color: n/a");
                }
            }
        }
    }
}
