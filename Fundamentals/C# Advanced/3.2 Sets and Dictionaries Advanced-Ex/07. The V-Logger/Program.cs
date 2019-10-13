namespace _07._The_V_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0].ToLower() == "statistics")
                {
                    break;
                }

                var vloggerName = input[0];
                if (input[1].ToLower() == "joined" && !vloggers.ContainsKey(vloggerName))
                {
                    vloggers[vloggerName] = new Dictionary<string, HashSet<string>>();
                    vloggers[vloggerName]["following"] = new HashSet<string>();
                    vloggers[vloggerName]["followers"] = new HashSet<string>();
                }
                else if (input[1].ToLower() == "followed" && vloggers.ContainsKey(vloggerName) && vloggers.ContainsKey(input[2]))
                {
                    if (vloggerName == input[2])
                    {
                        continue;
                    }

                    vloggers[vloggerName]["following"].Add(input[2]);
                    vloggers[input[2]]["followers"].Add(vloggerName);
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            vloggers = vloggers
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count)
                .ToDictionary(k => k.Key, v => v.Value);

            var counter = 1;
            foreach (var item in vloggers)
            {
                if (counter == 1)
                {
                    Console.WriteLine($"{counter}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["following"].Count} following");
                    var followers = item.Value["followers"].OrderBy(x => x).ToList();
                    foreach (var kvp in followers)
                    {
                        Console.WriteLine($"*  {kvp}");
                    }
                }
                else
                {
                    Console.WriteLine($"{counter}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["following"].Count} following");
                }

                counter++;
            }
        }
    }
}
