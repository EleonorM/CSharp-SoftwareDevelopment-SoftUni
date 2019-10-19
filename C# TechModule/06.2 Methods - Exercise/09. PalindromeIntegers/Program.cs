namespace _09._PalindromeIntegers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    return;
                }

                int[] numbers = input.ToString().Select(o => Convert.ToInt32(o)).ToArray();
                if (IsPalindrome(numbers))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        static bool IsPalindrome(int[] number)
        {

            for (int i = 0; i <= number.Length / 2; i++)
            {
                if (number[i] != number[number.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
