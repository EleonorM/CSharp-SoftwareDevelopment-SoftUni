namespace _05.Word_Filter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<string> words = Console.ReadLine().Split(' ').ToList();

            foreach (var word in words)
            {
                if (word.Length % 2 == 0)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
