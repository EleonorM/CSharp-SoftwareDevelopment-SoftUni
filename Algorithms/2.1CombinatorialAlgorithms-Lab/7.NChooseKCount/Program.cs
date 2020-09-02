namespace _7.NChooseKCount
{
    using System;

    public class Program
    {
        private static int combinations = 0;

        public static void Main()
        {
            var nums = int.Parse(Console.ReadLine());
            var positions = int.Parse(Console.ReadLine());

            GenerateCombinationsNOfK(nums, positions);

            Console.WriteLine(combinations);
        }

        private static void GenerateCombinationsNOfK(int n, int k)
        {
            var end = n - k + 1;
            GenerateCombinations(1, end, 0, k);
        }

        private static void GenerateCombinations(int start, int end, int currentNums, int n)
        {
            if (currentNums == n)
            {
                combinations++;
                return;
            }

            for (int i = start; i <= end; i++)
            {
                currentNums++;
                GenerateCombinations(i + 1, end + 1, currentNums, n);
                currentNums--;
            }
        }
    }
}
