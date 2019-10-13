namespace _05.Students
{
using System;
using System.Collections.Generic;
using System.Linq;

    public class Program
    {
        private class Student
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Age { get; set; }

            public string Hometown { get; set; }
        }

        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                var studentsList = input.Split().ToList();
                Student student = new Student();
                student.FirstName = studentsList[0];
                student.LastName = studentsList[1];
                student.Age = studentsList[2];
                student.Hometown = studentsList[3];
                students.Add(student);

            }
            var cityWanted = Console.ReadLine();
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Hometown == cityWanted)
                {
                    Console.WriteLine($"{students[i].FirstName} {students[i].LastName} is {students[i].Age} years old.");
                }
            }
        }
    }
}
