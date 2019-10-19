namespace _10._MultiplyEvensByOdds
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMultipleOfEvenAndOdds(Math.Abs(number)));
        }
        static int GetMultipleOfEvenAndOdds(int number)
        {
            return GetSumOfEvenDigits(number) * GetSumOfOddDigits(number);
        }

        static int GetSumOfEvenDigits(int number)
        {
            int evenSum = 0;
            while (number > 0)
            {
                int lastDigit = number % 10;
                number = number / 10;
                if (lastDigit % 2 == 0)
                {
                    evenSum += lastDigit;
                }
            }

            return evenSum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int oddSum = 0;
            while (number > 0)
            {
                int lastDigit = number % 10;
                number = number / 10;
                if (lastDigit % 2 != 0)
                {
                    oddSum += lastDigit;
                }
            }

            return oddSum;
        }
    }
}
