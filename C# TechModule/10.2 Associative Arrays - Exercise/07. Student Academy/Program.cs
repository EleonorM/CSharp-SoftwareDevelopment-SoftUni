namespace _07._Student_Academy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<double>>();
            for (int i = 0; i < rows; i++)
            {
                var name = Console.ReadLine();
                var grade = double.Parse(Console.ReadLine());
                if (!students.ContainsKey(name))
                {
                    students[name] = new List<double>();
                }
                students[name].Add(grade);
            }

            var result = students.Where(g => g.Value.Average() >= 4.5).OrderByDescending(x => x.Value.Average()).ToDictionary(k => k.Key, v => v.Value);
            foreach (var student in result)
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
            }
        }
    }
}
