namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        public int StudentId { get; set; }

        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; } = new List<Homework>();

        public ICollection<StudentCourse> CourseEnrollments { get; set; } = new List<StudentCourse>();
    }
}
