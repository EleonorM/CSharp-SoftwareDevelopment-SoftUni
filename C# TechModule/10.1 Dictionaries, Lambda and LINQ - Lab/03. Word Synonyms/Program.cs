namespace _03.Word_Synonyms
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var word = Console.ReadLine();
                var synonym = Console.ReadLine();
                if (dict.ContainsKey(word))
                {
                    dict[word].Add(synonym);
                }
                else
                {
                    dict.Add(word, new List<string>());
                    dict[word].Add(synonym);
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
