namespace _04.GenerateSubsetsOfStringArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<List<string>> combinations;

        public static void Main()
        {
            var inputStrings = Console.ReadLine().Split(", ").ToArray();
            var positions = int.Parse(Console.ReadLine());
            GenerateCombinations(inputStrings, positions);
            foreach (var combination in combinations)
            {
                Console.WriteLine($"({string.Join(" ", combination)})");
            }
        }

        private static void GenerateCombinations(string[] inputStrings, int k)
        {
            combinations = new List<List<string>>();
            var end = inputStrings.Length - k + 1;
            var currentNums = new List<string>();
            GenerateCombinations(0, end, currentNums, k, inputStrings);
        }

        private static void GenerateCombinations(int start, int end, List<string> currentNums, int n, string[] stringArray)
        {
            if (currentNums.Count == n)
            {
                var currentCombination = new List<string>(currentNums);
                combinations.Add(currentCombination);
                return;
            }

            for (int i = start; i < end; i++)
            {
                currentNums.Add(stringArray[i]);
                GenerateCombinations(i + 1, end + 1, currentNums, n, stringArray);
                currentNums.Remove(stringArray[i]);
            }
        }
    }
}
