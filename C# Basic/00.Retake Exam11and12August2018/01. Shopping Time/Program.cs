namespace _01.Shopping_Time
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var timeBreak = int.Parse(Console.ReadLine());
            var periferPrice = double.Parse(Console.ReadLine());
            var programPrice = double.Parse(Console.ReadLine());
            var frapePrice = double.Parse(Console.ReadLine());

            var timeLeft = timeBreak - 5 - 3 * 2 - 2 * 2;
            var moneySpend = 3 * periferPrice + 2 * programPrice + frapePrice;
            Console.WriteLine($"{moneySpend:f2}");
            Console.WriteLine(timeLeft);
        }
    }
}
