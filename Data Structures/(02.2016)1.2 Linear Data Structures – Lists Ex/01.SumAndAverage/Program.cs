namespace _01.SumAndAverage
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Sum=0; Average=0");
                return;
            }

            var nums = input.Split(" ").Select(x => int.Parse(x)).ToList();
            var sum = 0;
            var average = 0.0;
            foreach (var num in nums)
            {
                sum += num;
            }
            average = sum / (nums.Count * 1.0);

            Console.WriteLine($"Sum={sum}; Average={average}");
        }
    }
}
