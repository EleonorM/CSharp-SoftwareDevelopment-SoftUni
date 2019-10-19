namespace _05._DigitsLettersAndOther
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            List<char> nums = new List<char>();
            List<char> letters = new List<char>();
            List<char> other = new List<char>();
            foreach (char item in input)
            {
                if (item >= 48 && item <= 57)
                {
                    nums.Add(item);
                }
                else if (item >= 65 && item <= 90 || item >= 97 && item <= 122)
                {
                    letters.Add(item);
                }
                else
                {
                    other.Add(item);
                }
            }
            foreach (var item in nums)
            {
                Console.Write(item);
            }

            Console.WriteLine();
            foreach (var item in letters)
            {
                Console.Write(item);
            }

            Console.WriteLine();
            foreach (var item in other)
            {
                Console.Write(item);
            }
        }
    }
}
