namespace _06.Students_2._0
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
                string firstName = studentsList[0];
                string lastName = studentsList[1];
                if (IsExisting(students, firstName, lastName))
                {
                    Student student = GetStudent(students, firstName, lastName);
                    student.FirstName = studentsList[0];
                    student.LastName = studentsList[1];
                    student.Age = studentsList[2];
                    student.Hometown = studentsList[3];
                }
                else
                {
                    Student student2 = new Student();
                    student2.FirstName = studentsList[0];
                    student2.LastName = studentsList[1];
                    student2.Age = studentsList[2];
                    student2.Hometown = studentsList[3];
                    students.Add(student2);
                }
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

        private static bool IsExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }

        private static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student studentExisting = null;

            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    studentExisting = student;
                }

            }
            return studentExisting;
        }
    }
}
