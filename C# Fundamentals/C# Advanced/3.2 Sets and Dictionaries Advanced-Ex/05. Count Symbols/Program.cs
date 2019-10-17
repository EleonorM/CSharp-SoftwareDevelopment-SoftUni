namespace _05._Count_Symbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();
            var charSet = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                var letter = input[i];
                if (!charSet.ContainsKey(letter))
                {
                    charSet[letter] = 0;
                }
                charSet[letter]++;
            }

            foreach (var kvp in charSet)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
