namespace _7._Traffic_Jam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            var input = Console.ReadLine();
            int counter = 0;

            while (input != "end")
            {
                string removedCar;
                if (input == "green" && cars.Count >= n)
                {
                    for (int i = 0; i < n; i++)
                    {
                        removedCar = cars.Dequeue();
                        Console.WriteLine($"{removedCar} passed!");
                        counter++;

                    }
                }
                else if (input == "green" && cars.Count < n)
                {
                    while (cars.Any())
                    {
                        removedCar = cars.Dequeue();
                        Console.WriteLine($"{removedCar} passed!");
                        counter++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
