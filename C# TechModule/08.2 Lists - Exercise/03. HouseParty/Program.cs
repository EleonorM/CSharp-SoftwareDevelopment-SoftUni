namespace _03._HouseParty
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            var guests = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                var input = Console.ReadLine().Split();

                var name = input[0];
                if (input[2] == "not")
                {
                    if (!guests.Remove(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                else if (input[2] == "going!")
                {
                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
            }

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
