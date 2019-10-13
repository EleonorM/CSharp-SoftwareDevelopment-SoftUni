namespace _02.Odd_Occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<string> words = Console.ReadLine().ToLower().Split(' ').ToList();
            var result = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (result.ContainsKey(word))
                {
                    result[word]++;
                }
                else
                {
                    result.Add(word, 1);
                }
            }

            foreach (var item in result)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write($"{item.Key} ");
                }
            }
        }
    }
}
