namespace _08._Company_Users
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var companies = new SortedDictionary<string, List<string>>();
            while (true)
            {
                var input = Console.ReadLine().Split(" -> ");
                if (input[0] == "End")
                {
                    break;
                }
                var company = input[0];
                var id = input[1];
                if (!companies.ContainsKey(company))
                {
                    companies[company] = new List<string>();
                }
                if (!companies[company].Contains(id))
                {
                    companies[company].Add(id);
                }
            }

            foreach (var kvp in companies)
            {
                Console.WriteLine(kvp.Key);
                foreach (var value in kvp.Value)
                {
                    Console.WriteLine($"-- {value}");
                }
            }
        }
    }
}
