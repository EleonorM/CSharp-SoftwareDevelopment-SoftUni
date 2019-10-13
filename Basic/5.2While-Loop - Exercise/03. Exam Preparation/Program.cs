namespace _03.Exam_Preparation
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            double lowGrade = double.Parse(Console.ReadLine());
            int countLowGrade = 0;
            double gradeSum = 0.00;
            int gradeCount = 0;
            string lastName = "";
            while (true)
            {
                var name = Console.ReadLine();
                if (name == "Enough")
                {
                    Console.WriteLine($"Average score: {gradeSum / gradeCount:f2}");
                    Console.WriteLine($"Number of problems: {gradeCount}");
                    Console.WriteLine($"Last problem: {lastName}");
                    break;
                }

                var grade = double.Parse(Console.ReadLine());
                if (grade <= 4)
                    countLowGrade++;
                if (countLowGrade == lowGrade)
                {
                    Console.WriteLine($"You need a break, {lowGrade} poor grades.");
                    break;
                }

                gradeSum += grade;
                gradeCount++;
                lastName = name;
            }
        }
    }
}
