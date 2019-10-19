namespace _08._LettersChangeNumbers
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var regex = Regex.Matches(input, @"(?<firstLetter>[a-zA-Z])(?<num>[0-9]+)(?<lastLetter>[a-zA-Z])", RegexOptions.Multiline);
            var sum = 0.0;

            foreach (Match match in regex)
            {
                var currentSum = 0.0;
                var firstLetter = char.Parse(match.Groups["firstLetter"].Value);
                var num = double.Parse(match.Groups["num"].Value);
                var lastLetter = char.Parse(match.Groups["lastLetter"].Value);
                if (char.IsLower(firstLetter))
                {
                    currentSum += num * (firstLetter - 'a' + 1);
                }
                else if (char.IsUpper(firstLetter))
                {
                    currentSum += num / (firstLetter - 'A' + 1);
                }

                if (char.IsLower(lastLetter))
                {
                    currentSum += lastLetter - 'a' + 1;
                }
                else if (char.IsUpper(lastLetter))
                {
                    currentSum -= lastLetter - 'A' + 1;
                }

                sum += currentSum;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
