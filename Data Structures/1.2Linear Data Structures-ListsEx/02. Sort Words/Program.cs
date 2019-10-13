namespace _02._Sort_Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split().ToArray();
            var list = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                list.Add(words[i]);
            }

            list.Sort();
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
