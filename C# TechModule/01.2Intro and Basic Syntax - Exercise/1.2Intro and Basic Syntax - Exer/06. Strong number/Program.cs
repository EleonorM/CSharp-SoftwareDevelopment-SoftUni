using System;
using System.Linq;

namespace _06._Strong_number
{
    class Program
    {
        static long Factorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }
            return number * Factorial(number - 1);
        }
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Select(c => c - '0').ToArray();
            long sum = 0;
            foreach (var item in nums)
            {
                sum += Factorial(item);
            }

            if (sum == int.Parse(string.Join("", nums)))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
