namespace _01._Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var text = Console.ReadLine().ToCharArray().ToList();
            var result = new List<char>();
            for (int i = 0; i < numbers.Count; i++)
            {
                var number = numbers[i];
                var sum = 0;
                while (number != 0)
                {
                    sum += number % 10;
                    number /= 10;
                }

                if (sum <= text.Count)
                {
                    result.Add(text[sum]);
                    text.RemoveAt(sum);
                }
                else
                {
                    sum %= text.Count;
                    result.Add(text[sum]);
                    text.RemoveAt(sum);
                }
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}
