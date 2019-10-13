namespace _07.Scholarship
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var income = double.Parse(Console.ReadLine());
            var grade = double.Parse(Console.ReadLine());
            var minSalary = double.Parse(Console.ReadLine());

            var socialMoney = 0.00;
            var excellentMoney = 0.00;
            if (income <= minSalary && grade > 4.5)
            {
                socialMoney = 0.35 * minSalary;
            }
            if (grade >= 5.5)
            {
                excellentMoney = grade * 25.0;
            }

            if (socialMoney > excellentMoney && income <= minSalary)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialMoney)} BGN");
            }
            else if (excellentMoney >= socialMoney && excellentMoney != 0)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentMoney)} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
