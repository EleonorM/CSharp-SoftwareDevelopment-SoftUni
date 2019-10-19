namespace _02._RepeatStrings
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split().ToArray();
            for (int i = 0; i < words.Length; i++)
            {
                for (int k = 0; k < words[i].Length; k++)
                {
                    Console.Write(words[i]);
                }
            }
        }
    }
}
