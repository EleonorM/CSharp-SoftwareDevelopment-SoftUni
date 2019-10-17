namespace _03._Legendary_Farming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var materials = new Dictionary<string, int>();
            materials["shards"] = 0;
            materials["fragments"] = 0;
            materials["motes"] = 0;
            var junk = new SortedDictionary<string, int>();
            var result = "";

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < input.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        if (input[i].ToLower() == "shards" || input[i].ToLower() == "fragments" || input[i].ToLower() == "motes")
                        {
                            materials[input[i].ToLower()] += int.Parse(input[i - 1]);
                            if (materials[input[i].ToLower()] >= 250 && (input[i].ToLower() == "shards" || input[i].ToLower() == "fragments" || input[i].ToLower() == "motes"))
                            {
                                materials[input[i].ToLower()] -= 250;
                                result = input[i].ToLower();
                                break;
                            }
                        }
                        else
                        {
                            if (!junk.ContainsKey(input[i].ToLower()))
                            {
                                junk[input[i].ToLower()] = 0;
                            }
                            junk[input[i].ToLower()] += int.Parse(input[i - 1]);
                        }
                    }
                }

                if (result.Length > 0)
                {
                    break;
                }
            }

            var print = materials
                .OrderByDescending(m => m.Value)
                .ThenBy(m => m.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            if (result == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (result == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else if (result == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
            }

            foreach (var kvp in print)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junk)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
