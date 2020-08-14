namespace _04.RepresentingSumWithUnlimitedAmountOfCoins
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int combinations = 0;
        private static int sum;
        private static int currentSum;

        public static void Main()
        {
            var nums = Console.ReadLine().Split(new char[] { ' ' }).Select(int.Parse).ToArray();
            sum = int.Parse(Console.ReadLine());

            CalculateCombinations(nums);
            Console.WriteLine(combinations);
        }

        private static void CalculateCombinations(int[] nums)
        {
            CalculateCombinations(nums, 0, nums.Length - 1);
        }

        private static void CalculateCombinations(int[] nums, int currentSum, int currentIndex)
        {
            if (currentSum == sum)
            {
                combinations++;
                return;
            }

            for (int i = currentIndex; i >= 0; i--)
            {
                if (nums[i] <= sum - currentSum)
                {
                    currentSum += nums[i];
                    CalculateCombinations(nums, currentSum, i);
                    currentSum -= nums[i];
                }
            }

        }
    }
}
