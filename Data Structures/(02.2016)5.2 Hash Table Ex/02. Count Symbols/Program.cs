namespace _02._Count_Symbols
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();
            var charOccurencies = new HashTable<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!charOccurencies.ContainsKey(input[i]))
                {
                    charOccurencies.Add(input[i], 0);
                }
                charOccurencies[input[i]]++;
            }

            var orderedOccurencies = charOccurencies.OrderBy(x => x).ToList();
            foreach (var occurency in orderedOccurencies)
            {
                Console.WriteLine($"{occurency.Key}: {occurency.Value} time/s");
            }
        }
    }
}
