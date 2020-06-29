namespace _05.CountOfOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            var nums = input.Split(" ").Select(x => int.Parse(x)).ToList();
            var numsOccurences = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!numsOccurences.ContainsKey(num))
                {
                    numsOccurences[num] = 0;
                }

                numsOccurences[num]++;
            }

            numsOccurences = numsOccurences.OrderBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in numsOccurences)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value} times");
            }
        }
    }
}
