namespace _01._Trojan_Invasion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static int currentPlate;
        public static int currentPower;
        public static void Main()
        {
            var wavesOfWarrior = int.Parse(Console.ReadLine());
            var firstPlates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var plates = new List<int>(firstPlates);
            var power = new Stack<int>();
            for (int i = 1; i <= wavesOfWarrior; i++)
            {
                var powerOfWarrior = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (plates.Count != 0)
                {
                    foreach (var item in powerOfWarrior)
                    {
                        power.Push(item);
                    }

                    if (i % 3 == 0)
                    {
                        plates.Add(int.Parse(Console.ReadLine()));
                    }

                    Fight(plates, power);
                }
            }

            if (power.Count != 0)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
            }


            if (power.Count != 0)
            {
                Console.WriteLine($"Warriors left: {string.Join(", ", power)}");
            }
            else
            {
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");

            }
        }

        public static void Fight(List<int> platesList, Stack<int> powerList)
        {
            while (powerList.Count != 0 && platesList.Count != 0)
            {
                currentPlate = platesList[0];
                currentPower = powerList.Pop();

                if (currentPlate - currentPower > 0)
                {
                    currentPlate -= currentPower;
                    platesList[0] = currentPlate;
                }
                else if (currentPlate - currentPower < 0)
                {
                    currentPower -= currentPlate;
                    powerList.Push(currentPower);
                    platesList.RemoveAt(0);
                }
                else
                {
                    platesList.RemoveAt(0);

                }

                if (platesList.Count == 0)
                {
                    break;
                }
            }
        }
    }
}
