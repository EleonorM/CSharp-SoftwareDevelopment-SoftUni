namespace _01._DayOfWeek
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] days =
               {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            var day = int.Parse(Console.ReadLine());
            if (1 <= day && day <= 7)
                Console.WriteLine(days[day - 1]);
            else
                Console.WriteLine("Invalid day!");
        }
    }
}
