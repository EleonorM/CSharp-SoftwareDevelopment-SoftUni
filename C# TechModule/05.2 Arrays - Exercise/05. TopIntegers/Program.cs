namespace _05._TopIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> biggerNumbers = new List<int>();

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] > input[i + 1])
                {
                    biggerNumbers.Add(input[i]);
                }
            }

            biggerNumbers.Add(input[input.Length - 1]);

            Console.WriteLine(string.Join(" ", biggerNumbers));
        }
    }
}
