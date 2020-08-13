namespace _03.DividingPresents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var presents = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var totalSum = presents.Sum();

            var sums = new int[totalSum + 1];
            for (int i = 1; i < sums.Length; i++)
            {
                sums[i] = -1;
            }

            for (int presIndex = 0; presIndex < presents.Length; presIndex++)
            {
                for (int prevSumIndex = totalSum - presents[presIndex]; prevSumIndex >= 0; prevSumIndex--)
                {
                    if (sums[prevSumIndex] != -1 && sums[prevSumIndex + presents[presIndex]] == -1)
                    {
                        sums[prevSumIndex + presents[presIndex]] = presIndex;
                    }
                }
            }

            var halfSum = totalSum / 2;

            for (int i = halfSum; i >= 0; i--)
            {
                if (sums[i] == -1)
                {
                    continue;
                }

                Console.WriteLine($"Difference: {totalSum - i - i}");
                Console.WriteLine($"Alan:{i} Bob:{totalSum - i}");

                var alansPresents = new List<int>();
                while (i != 0)
                {
                    alansPresents.Add(presents[sums[i]]);
                    i -= presents[sums[i]];
                }

                Console.WriteLine($"Alan takes: {string.Join(" ", alansPresents)}");
                Console.WriteLine("Bob takes the rest.");
            }
        }
    }
}
