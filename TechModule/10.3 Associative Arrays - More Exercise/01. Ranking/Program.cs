namespace _01._Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var contests = new Dictionary<string, string>();
            var users = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var input = Console.ReadLine().Split(":");
                if (input[0] == "end of contests")
                {
                    break;
                }
                contests[input[0]] = input[1];
            }

            while (true)
            {
                var input = Console.ReadLine().Split("=>");
                if (input[0] == "end of submissions")
                {
                    break;
                }
                var contest = input[0];
                var password = input[1];
                var username = input[2];
                var points = int.Parse(input[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (users.ContainsKey(username))
                    {
                        if (users[username].ContainsKey(contest))
                        {
                            if (users[username][contest] < points)
                            {
                                users[username][contest] = points;
                            }
                        }
                        else
                        {
                            users[username].Add(contest, points);
                        }
                    }
                    else
                    {
                        users[username] = new Dictionary<string, int>();
                        users[username][contest] = points;
                    }
                }
            }

            Dictionary<string, int> usersTootalPoints = new Dictionary<string, int>();
            foreach (var kvp in users)
            {
                usersTootalPoints[kvp.Key] = kvp.Value.Values.Sum();
            }

            int maxPoints = usersTootalPoints
                .Values
                .Max();

            foreach (var kvp in usersTootalPoints)
            {
                if (kvp.Value == maxPoints)
                {
                    Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value} points.");

                }
            }

            Console.WriteLine("Ranking:");

            foreach (var kvp in users)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine(string.Join(Environment.NewLine, kvp.Value
                    .OrderByDescending(x => x.Value)
                    .Select(a => $"#  {a.Key} -> {a.Value}")
                    ));
            }
        }
    }
}
