namespace _03._TreasureFinder
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var key = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "find")
                {
                    break;
                }

                var counter = 0;
                var result = string.Empty;
                for (int i = 0; i < input.Length; i++)
                {
                    if (counter >= key.Count)
                    {
                        counter = 0;
                    }
                    result += (char)((int)input[i] - key[counter]);
                    counter++;
                }

                var regex = Regex.Matches(result, @"&(?<word>\w+)&[\w\s]+<(?<coordinate>\w+)>", RegexOptions.Multiline);

                foreach (Match match in regex)
                {
                    Console.WriteLine($"Found {match.Groups["word"].Value} at {match.Groups["coordinate"].Value}");
                }
            }
        }
    }
}
