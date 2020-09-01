namespace _03.GenerateCombinationsIteratively
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static List<List<int>> combinations;

        public static void Main()
        {
            var nums = int.Parse(Console.ReadLine());
            var positions = int.Parse(Console.ReadLine());

            GenerateCombinationsNOfK(nums, positions);

            foreach (var combination in combinations)
            {
                Console.WriteLine(string.Join(" ", combination));
            }
        }

        private static void GenerateCombinationsNOfK(int n, int k)
        {
            combinations = new List<List<int>>();
            var end = n - k + 1;
            var currentNums = new List<int>();
            GenerateCombinations(1, end, currentNums, k);

        }

        private static void GenerateCombinations(int start, int end, List<int> currentNums, int n)
        {
            if (currentNums.Count == n)
            {
                var currentCombination = new List<int>(currentNums);
                combinations.Add(currentCombination);
                return;
            }

            for (int i = start; i <= end; i++)
            {
                currentNums.Add(i);
                GenerateCombinations(i + 1, end + 1, currentNums, n);
                currentNums.Remove(i);
            }
        }

    }
}
