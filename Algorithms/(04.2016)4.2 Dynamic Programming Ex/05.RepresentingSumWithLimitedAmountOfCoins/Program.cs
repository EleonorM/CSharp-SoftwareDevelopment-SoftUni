namespace _05.RepresentingSumWithLimitedAmountOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static HashSet<List<int>> combinations = new HashSet<List<int>>();
        private static int sum;

        public static void Main()
        {
            var nums = Console.ReadLine().Split(new char[] { ' ' }).Select(int.Parse).ToArray();
            sum = int.Parse(Console.ReadLine());

            CalculateCombinations(nums);
            Console.WriteLine(combinations.Count);
        }

        private static void CalculateCombinations(int[] nums)
        {
            var a = new List<int>();
            CalculateCombinations(nums, 0, nums.Length - 1, a);
        }

        private static void CalculateCombinations(int[] nums, int currentSum, int currentIndex, List<int> currComb)
        {
            if (currentSum == sum)
            {
                if (combinations.Any(x => x.All(currComb.Contains) && x.Count == currComb.Count))
                {
                    return;
                }
                var list = new List<int>();
                list.AddRange(currComb);
                combinations.Add(list);
                return;
            }

            for (int i = currentIndex; i >= 0; i--)
            {
                if (nums[i] <= sum - currentSum)
                {

                    currComb.Add(nums[i]);
                    currentSum += nums[i];
                    CalculateCombinations(nums, currentSum, i - 1, currComb);
                    currComb.Remove(nums[i]);
                    currentSum -= nums[i];
                }
            }

        }
    }
}
