namespace _1.Recursive_Array_Sum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static int Sum(int[] numbers, int index)
        {
            if (index == numbers.Length)
            {
                return 0;
            }
            // Console.WriteLine("Before +" + index);
            var currentSum = numbers[index] + Sum(numbers, index + 1);
            // Console.WriteLine("After +" + index);

            return currentSum;
        }
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var sum = Sum(numbers, 0);
            Console.WriteLine(sum);
        }
    }
}
