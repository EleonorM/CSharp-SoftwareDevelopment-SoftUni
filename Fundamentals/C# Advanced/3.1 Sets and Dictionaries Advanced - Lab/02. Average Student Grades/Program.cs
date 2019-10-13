namespace _02._Average_Student_Grades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var marks = new Dictionary<string, List<double>>();

            int allMarks = int.Parse(Console.ReadLine());
            for (int i = 0; i < allMarks; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                var name = input[0];
                double mark = double.Parse(input[1]);

                if (!marks.ContainsKey(name))
                {
                    marks[name] = new List<double>();
                    marks[name].Add(mark);
                }
                else
                {
                    marks[name].Add(mark);
                }
            }

            foreach (var kvp in marks)
            {
                var name = kvp.Key;
                var mark = kvp.Value;
                double average = mark.Average();
                Console.WriteLine($"{name} -> {string.Join(" ", mark.Select(x => String.Format($"{x:f2}")))} (avg: {average:f2})");
            }
        }
    }
}
