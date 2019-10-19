namespace _04._TextFilter
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] words = Console.ReadLine()
                   .Split(new[] { ' ', ',', }, StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (var word in words)
            {
                var replacement = new string('*', word.Length);
                text = text.Replace(word, replacement);
            }

            Console.WriteLine(text);
        }
    }
}
