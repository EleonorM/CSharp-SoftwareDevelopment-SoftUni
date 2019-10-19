namespace _10._TopNumber
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var range = int.Parse(Console.ReadLine());
            PrintTopNumbers(range);
        }

        static void PrintTopNumbers(int range)
        {
            for (int i = 8; i < range; i++)
            {
                if (OneOddDigit(i) && IsDevisibleBy8(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsDevisibleBy8(int num)
        {
            var sum = 0;
            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }

            if (sum == 0)
            {
                return false;
            }
            else if (sum % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool OneOddDigit(int num)
        {
            while (num != 0)
            {
                var oddNum = num % 10;
                num /= 10;
                if (oddNum % 2 != 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
