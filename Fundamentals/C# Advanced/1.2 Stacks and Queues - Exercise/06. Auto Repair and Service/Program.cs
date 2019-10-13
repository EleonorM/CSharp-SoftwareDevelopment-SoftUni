namespace _06._Auto_Repair_and_Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var vehicle = new Queue<string>();
            var carNumber = Console.ReadLine();
            var servedCars = new Stack<string>();
            var regex = Regex.Matches(carNumber, @"(?<car>\w+)\s?", RegexOptions.Multiline);

            foreach (Match match in regex)
            {
                vehicle.Enqueue(match.Groups["car"].ToString());
            }

            while (true)
            {
                var input = Console.ReadLine().Split("-");
                var action = input[0];
                if (action == "End")
                {
                    break;
                }
                else if (action == "Service")
                {
                    try
                    {
                        var vehicleName = vehicle.Dequeue();
                        servedCars.Push(vehicleName);
                        Console.WriteLine($"Vehicle {vehicleName} got served.");
                    }
                    catch
                    {
                    }
                }
                else if (action == "CarInfo")
                {
                    if (vehicle.Contains(input[1]))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }
                else if (action == "History")
                {
                    Console.WriteLine($"{string.Join(", ", servedCars)}");
                }
            }

            if (vehicle.Count != 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", vehicle)}");
            }

            if (servedCars.Count != 0)
            {
                Console.WriteLine($"Served vehicles: {string.Join(", ", servedCars)}");
            }
        }
    }
}
