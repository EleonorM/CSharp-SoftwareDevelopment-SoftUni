namespace _01._ReverseStrings
{
    using System;

    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                var word = Console.ReadLine();
                if (word == "end")
                {
                    break;
                }

                string reversed = string.Empty;
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    reversed += word[i];
                }

                Console.WriteLine($"{word} = {reversed}");
            }
        }
    }
}
