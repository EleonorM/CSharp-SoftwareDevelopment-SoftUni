namespace _03.Computer_Room
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var month = Console.ReadLine().ToLower();
            var timeSpend = int.Parse(Console.ReadLine());
            var people = int.Parse(Console.ReadLine());
            var time = Console.ReadLine().ToLower();
            var tax = 0.00;

            if (month == "march" || month == "april" || month == "may")
            {
                if (time == "day")
                    tax = 10.5;
                else if (time == "night")
                    tax = 8.4;
            }
            else if (month == "june" || month == "july" || month == "august")
            {
                if (time == "day")
                    tax = 12.6;
                else if (time == "night")
                    tax = 10.2;
            }

            if (people >= 4)
            {
                tax -= 0.1 * tax;
            }

            if (timeSpend >= 5)
            {
                tax -= 0.5 * tax;
            }

            Console.WriteLine($"Price per person for one hour: {tax:f2}");
            Console.WriteLine($"Total cost of the visit: {tax * people * timeSpend:f2}");
        }
    }
}
