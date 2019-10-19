namespace _06._ReplaceRepeatingChars
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var counter = 0;
            var result = new List<char>();
            MatchCollection regex = Regex.Matches(input, @"([a-z])\1*", RegexOptions.Multiline);
            foreach (Match match in regex)
            {
                var character = match.Value[0];
                result.Add(character);
            }

            Console.WriteLine(string.Concat(result));
        }
    }
}
