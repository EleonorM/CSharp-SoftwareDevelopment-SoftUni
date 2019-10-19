namespace _07._MaxSequenceOfEqualElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> result = new List<int>();
            List<int> result2 = new List<int>();

            for (int i = 1; i < numbers.Length; i++)
            {
                if (i == 1)
                {
                    result.Add(numbers[0]);
                }
                if (numbers[i] == numbers[i - 1])
                {
                    result.Add(numbers[i]);
                }
                else
                {
                    result.Clear();
                    result.Add(numbers[i]);
                }
                if (numbers.Length - 2 == numbers.Length - 1 && i == numbers.Length - 1)
                {
                    result.Add(numbers[numbers.Length - 1]);
                }
                if (result.Count > result2.Count)
                {
                    result2.Clear();
                    for (int j = 0; j < result.Count; j++)
                    {
                        var currentNumber = result[j];
                        result2.Add(currentNumber);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", result2));
        }
    }
}
