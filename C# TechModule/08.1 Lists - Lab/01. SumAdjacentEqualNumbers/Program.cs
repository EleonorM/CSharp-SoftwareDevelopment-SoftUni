namespace _01._SumAdjacentEqualNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                double currentNumber = numbers[i];
                double nextNumber = numbers[i + 1];
                if (currentNumber == nextNumber)
                {
                    numbers[i] = numbers[i] * 2;
                    numbers.RemoveAt(i + 1);
                    i = -1;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
