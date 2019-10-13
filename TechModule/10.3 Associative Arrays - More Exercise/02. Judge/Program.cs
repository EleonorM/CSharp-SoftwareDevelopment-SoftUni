namespace _02._Judge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static void Main()
        {
            var contests = new Dictionary<string, Dictionary<string, int>>();
            var individualPoint = new Dictionary<string, int>();
            while (true)
            {
                var input = Console.ReadLine().Split(" -> ");
                if (input[0] == "no more time")
                {
                    break;
                }

                var username = input[0];
                var contest = input[1];
                var points = int.Parse(input[2]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest].ContainsKey(username))
                    {
                        if (contests[contest][username] < points)
                        {
                            contests[contest][username] = points;
                        }
                    }
                    else
                    {
                        contests[contest][username] = points;
                    }
                }
                else
                {
                    contests[contest] = new Dictionary<string, int>
                    {
                        [username] = points
                    };
                }
            }

            foreach (var kvp in contests)
            {
                foreach (var value in kvp.Value)
                {
                    if (individualPoint.ContainsKey(value.Key))
                    {
                        individualPoint[value.Key] += value.Value;
                    }
                    else
                    {
                        individualPoint[value.Key] = value.Value;
                    }
                }
            }

            foreach (var kvp in contests)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} participants");
                Dictionary<string, int> dict = kvp.Value;
                dict = dict.OrderByDescending(x => x.Value).ThenBy(y => y.Key).ToDictionary(k => k.Key, v => v.Value);
                var counter = 0;
                foreach (var value in dict)
                {
                    counter++;
                    Console.WriteLine($"{counter}. {value.Key} <::> {value.Value}");
                }
            }

            Console.WriteLine("Individual standings:");
            var result = individualPoint.OrderByDescending(x => x.Value).ThenBy(n => n.Key).ToDictionary(k => k.Key, v => v.Value);
            var counter2 = 0;

            foreach (var kvp in result)
            {
                counter2++;
                Console.WriteLine($"{counter2}. {kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
