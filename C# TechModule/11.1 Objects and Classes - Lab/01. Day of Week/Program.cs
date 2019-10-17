namespace _01.Day_of_Week
{
    using System;
    using System.Globalization;

    public class Program
    {
        private static void Main()
        {
            var input = Console.ReadLine();
            var datetime = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(datetime.DayOfWeek);
        }
    }
}
