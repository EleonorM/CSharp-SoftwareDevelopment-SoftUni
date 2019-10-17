namespace _10._SoftUni_Exam_Results
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var students = new Dictionary<string, int>();
            var languages = new Dictionary<string, int>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "exam finished")
                {
                    break;
                }

                string[] inputParts = input.Split("-");
                var username = inputParts[0];
                if (inputParts[1] == "banned")
                {
                    students.Remove(username);
                    continue;
                }

                var language = inputParts[1];
                var points = int.Parse(inputParts[2]);
                if (students.ContainsKey(username) && students[username] < points)
                {
                    students[username] = points;
                }
                else if (!students.ContainsKey(username))
                {
                    students[username] = points;
                }

                if (languages.ContainsKey(language))
                {
                    languages[language]++;
                }
                else
                {
                    languages[language] = 1;
                }
            }

            var studentResult = students.OrderByDescending(p => p.Value).ThenBy(u => u.Key).ToDictionary(k => k.Key, v => v.Value);
            Console.WriteLine("Results:");
            foreach (var kvp in studentResult)
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            var langageResult = languages.OrderByDescending(p => p.Value).ThenBy(u => u.Key).ToDictionary(k => k.Key, v => v.Value);
            Console.WriteLine("Submissions:");
            foreach (var kvp in langageResult)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
