namespace _03.Volleyball
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var year = Console.ReadLine();
            var p = int.Parse(Console.ReadLine());
            var h = int.Parse(Console.ReadLine());

            var gameSofia = 48 - h;
            double saturdayGame = gameSofia * 3 / 4.0 + p * 2 / 3.0 + h;
            if (year == "leap")
            {
                Console.WriteLine(Math.Floor(saturdayGame * 0.15 + saturdayGame));
            }
            else
            {
                Console.WriteLine(Math.Floor(saturdayGame));
            }
        }
    }
}
