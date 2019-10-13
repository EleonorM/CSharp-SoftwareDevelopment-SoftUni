namespace _06._Courses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var courses = new Dictionary<string, List<string>>();
            while (true)
            {
                var input = Console.ReadLine().Split(" : ");
                if (input[0] == "end")
                {
                    break;
                }

                var course = input[0];
                var personName = input[1];
                if (!courses.ContainsKey(course))
                {
                    courses[course] = new List<string>();
                }

                courses[course].Add(personName);
            }

            foreach (var course in courses)
            {
                courses[course.Key].Sort();
            }

            var result = courses
                .OrderByDescending(c => c.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                foreach (var name in kvp.Value)
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
