namespace _09._ForceBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var users = new Dictionary<string, List<string>>();

            while (true)
            {
                var inputA = Console.ReadLine();
                if (inputA == "Lumpawaroo")
                {
                    break;
                }

                try
                {
                    var input = inputA.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    var forceSide = input[0];
                    var forceUser = input[1];
                    var counrer = 0;
                    foreach (var kvp in users)
                    {
                        if (kvp.Value.Contains(forceUser))
                        {
                            counrer++;
                            break;
                        }
                    }
                    if (counrer != 0)
                    {
                        continue;
                    }
                    if (!users.ContainsKey(forceSide))
                    {
                        users[forceSide] = new List<string>();
                    }
                    if (!users[forceSide].Contains(forceUser))
                    {
                        users[forceSide].Add(forceUser);
                    }
                }
                catch (Exception)
                {
                }

                try
                {
                    var input = inputA.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    var forceUser = input[0];
                    var forceSide = input[1];
                    var counter = 0;
                    foreach (var kvp in users)
                    {
                        if (kvp.Value.Contains(forceUser))
                        {
                            kvp.Value.Remove(forceUser);
                            counter++;
                        }
                    }
                    if (counter != 0)
                    {
                        if (!users.ContainsKey(forceSide))
                        {
                            users[forceSide] = new List<string>();
                        }
                        if (!users[forceSide].Contains(forceUser))
                        {
                            users[forceSide].Add(forceUser);
                        }
                    }
                    else
                    {
                        if (!users.ContainsKey(forceSide))
                        {
                            users[forceSide] = new List<string>();
                        }
                        if (!users[forceSide].Contains(forceUser))
                        {
                            users[forceSide].Add(forceUser);
                        }
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
                catch (Exception)
                {
                }
            }

            foreach (var item in users)
            {
                item.Value.Sort();
            }

            var result = users.OrderByDescending(u => u.Value.Count).ThenBy(n => n.Key).ToDictionary(k => k.Key, v => v.Value);
            foreach (var kvp in result)
            {
                if (kvp.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");
                    foreach (var value in kvp.Value)
                    {
                        Console.WriteLine($"! {value}");
                    }
                }
            }
        }
    }
}
