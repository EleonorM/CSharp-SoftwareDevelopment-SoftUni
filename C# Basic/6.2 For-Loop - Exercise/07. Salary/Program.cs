namespace _07.Salary
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var numberTab = int.Parse(Console.ReadLine());
            var salary = double.Parse(Console.ReadLine());

            for (int i = 0; i < numberTab; i++)
            {
                var tabName = Console.ReadLine();
                if (tabName == "Facebook")
                {
                    salary -= 150;
                }
                else if (tabName == "Instagram")
                {
                    salary -= 100;
                }
                else if (tabName == "Reddit")
                {
                    salary -= 50;
                }
                else
                {
                    salary -= 0;
                }

                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    return;
                }
            }

            Console.WriteLine(salary);
        }
    }
}
