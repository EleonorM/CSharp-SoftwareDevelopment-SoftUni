namespace _01._ExtractPersonInformation
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine();
                // var regex = Regex.Matches(input, @"(((?<name>(?<=@)[a-zA-Z\s]+)\|)[^#]*(#(?<age>\d+)\*))", RegexOptions.Multiline);
                var regexName = Regex.Matches(input, @"(?<name>(?<=@)[a-zA-Z\s]+)\|", RegexOptions.Multiline);
                var regexAge = Regex.Matches(input, @"(#(?<age>\d+)\*)", RegexOptions.Multiline);

                for (int j = 0; j < Math.Max(regexName.Count, regexAge.Count); j++)
                {
                    var name = regexName[j].Groups["name"].Value;
                    var age = regexAge[j].Groups["age"].Value;
                    Console.WriteLine($"{name} is {age} years old.");
                }
            }
        }
    }
}
