namespace _2.Recursive_Factorial
{
    using System;

    public class Program
    {
        public static long Factorial(long number)
        {
            if (number == 0)
            {
                return 1;
            }

            var currentSum = (number) * Factorial(number - 1);
            return currentSum;
        }

        public static void Main()
        {
            long number = long.Parse(Console.ReadLine());

            var sum = Factorial(number);
            Console.WriteLine(sum);
        }
    }
}
