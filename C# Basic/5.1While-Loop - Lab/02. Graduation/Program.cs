namespace _02.Graduation
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var sum = 0.00;
            int counter = 1;
            while (counter <= 12)
            {
                var grade = double.Parse(Console.ReadLine());
                if (grade >= 4)
                {
                    sum += grade;
                    counter++;
                }
            }

            Console.WriteLine($"{name} graduated. Average grade: {sum / 12.0:f2}");
        }
    }
}
