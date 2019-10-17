namespace _06._Wardrobe
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var wardrobe = new Dictionary<string, Dictionary<string,int>>();
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (!wardrobe.ContainsKey(input[0]))
                {
                    wardrobe[input[0]] = new Dictionary<string, int>();
                }

                var clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in clothes)
                {
                    if (!wardrobe[input[0]].ContainsKey(item))
                    {
                        wardrobe[input[0]][item] = 0;
                    }
                    wardrobe[input[0]][item]++;
                }
            }

            var searched = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var item in kvp.Value)
                {
                    if (searched[0] == kvp.Key && searched[1] == item.Key)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
