namespace _04._MorseCodeTranslator
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                { ".-", "a" },
                { "-...", "b" },
                { "-.-.", "c" },
                { "-..", "d" },
                { ".", "e" },
                { "..-.", "f" },
                { "--.", "g" },
                { "....", "h" },
                { "..", "i" },
                { ".---", "j" },
                { "-.-", "k" },
                { ".-..", "l" },
                { "--", "m" },
                { "-.", "n" },
                { "---", "o" },
                { ".--.", "p" },
                { "--.-", "q" },
                { ".-.", "r" },
                { "...", "s" },
                { "-", "t" },
                { "..-", "u" },
                { "...-", "v" },
                { ".--", "w" },
                { "-..-", "x" },
                { "-.--", "y" },
                { "--..", "z" },
                { "|", " " },
            };

            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var result = string.Empty;
            for (int i = 0; i < input.Count; i++)
            {
                result += map[input[i]];
            }

            Console.WriteLine(result.ToUpper());
        }
    }
}
