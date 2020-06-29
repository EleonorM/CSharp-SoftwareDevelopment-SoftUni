namespace _03.LongestSubsequence
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
            var longest = new List<int>();
            var current = new List<int>();
            foreach (var num in nums)
            {
                if (current.Contains(num))
                {
                    current.Add(num);
                }
                else
                {
                    if (longest.Count < current.Count)
                    {
                        longest.Clear();
                        longest.AddRange(current);
                    }

                    current.Clear();
                    current.Add(num);
                }
            }

            if (longest.Count < current.Count)
            {
                longest.Clear();
                longest.AddRange(current);
            }

            Console.WriteLine(string.Join(" ", longest));
        }
    }
}
