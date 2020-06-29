namespace _04.RemoveOddOccurences
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

            foreach (var kvp in numsOccurences)
            {
                if (kvp.Value % 2 != 0)
                {
                    nums.RemoveAll(x => x == kvp.Key);
                }
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
