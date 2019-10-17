namespace _04._Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var students = new List<Student>();
            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split().ToList();
                var student = new Student();
                student.FirstName = input[0];
                student.LastName = input[1];
                student.Grade = double.Parse(input[2]);
                students.Add(student);
            }

            students = students.OrderBy(o => o.Grade).Reverse().ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
    public class Student
    {
        public string FirstName;
        public string LastName;
        public double Grade;
    }
}
