namespace _07._Truck_Tour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var gasStataions = new Queue<int[]>();
            var numberOfStations = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfStations; i++)
            {
                var currentStation = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                gasStataions.Enqueue(currentStation);
            }

            var gasStationNumber = 0;
            while (true)
            {
                var amountOfGas = 0;
                foreach (var currentStation in gasStataions)
                {
                    var liters = currentStation[0];
                    var km = currentStation[1];
                    amountOfGas += liters - km;
                    if (amountOfGas < 0)
                    {
                        gasStataions.Enqueue(gasStataions.Dequeue());
                        gasStationNumber++;
                        break;
                    }
                }

                if (amountOfGas >= 0)
                {

                    break;
                }
            }

            Console.WriteLine(gasStationNumber);
        }
    }
}
