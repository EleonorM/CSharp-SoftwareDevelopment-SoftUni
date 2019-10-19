using System;

namespace _06._Strong_number1
{
    class Program
    {
        static void Main(string[] args)
        {
            int originNumber = int.Parse(Console.ReadLine());
            int sum = 0;
            int number = originNumber;
            while (number > 0)
            {
                int lastDigit = number % 10;
                number /= 10;
                int currentFactorial = 1;
                for (int i = 2; i <= lastDigit; i++)
                {
                    currentFactorial *= i;
                }
                sum += currentFactorial;
            }
            bool isStrong = sum == originNumber;
            if (isStrong)
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
