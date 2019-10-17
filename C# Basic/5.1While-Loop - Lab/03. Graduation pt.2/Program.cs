namespace _03.Graduation_pt._2
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var sum = 0.00;
            int counter = 1;
            int counter2 = 0;
            while (counter <= 12)
            {
                var grade = double.Parse(Console.ReadLine());
                if (grade >= 4)
                {
                    sum += grade;
                    counter++;
                    if (counter > 12)
                        Console.WriteLine($"{name} graduated. Average grade: {sum / 12.0:f2}");
                }
                else
                {
                    counter2++;
                }

                if (counter2 > 1)
                {
                    Console.WriteLine($"{name} has been excluded at {counter} grade");
                    break;
                }
            }
        }
    }
}
