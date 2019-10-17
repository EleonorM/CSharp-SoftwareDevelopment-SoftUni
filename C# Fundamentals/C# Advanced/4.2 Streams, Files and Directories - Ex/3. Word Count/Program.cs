namespace _3._Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var wordsCount = new Dictionary<string, int>();
            var path = "words";
            var file = "words.txt";

            using (var reader = new StreamReader(Path.Combine(path, file)))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    wordsCount.Add(line, 0);
                }
            }

            using (var reader = new StreamReader("text.txt"))
            {
                while (true)
                {
                    var line = reader.ReadToEnd();
                    if (line == string.Empty)
                    {
                        break;
                    }

                    var regex = Regex.Matches(line, @"\w+", RegexOptions.Multiline);

                    foreach (Match match in regex)
                    {
                        if (wordsCount.ContainsKey(match.ToString().ToLower()))
                        {
                            wordsCount[match.ToString().ToLower()]++;
                        }
                    }
                }
            }

            using (var writer = new StreamWriter("actualResults.txt"))
            {
                foreach (var kvp in wordsCount)
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }

            wordsCount = wordsCount.OrderByDescending(x => x.Value).ToDictionary(k => k.Key, v => v.Value);

            using (var writer = new StreamWriter("expectedResult.txt"))
            {
                foreach (var kvp in wordsCount)
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}
