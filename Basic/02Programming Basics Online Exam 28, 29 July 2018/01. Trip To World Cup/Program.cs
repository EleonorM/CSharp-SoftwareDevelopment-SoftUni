namespace _01.Trip_To_World_Cup
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var monyeForGoing = double.Parse(Console.ReadLine());
            var monyeForGoingBack = double.Parse(Console.ReadLine());
            var billet = double.Parse(Console.ReadLine());
            var matches = int.Parse(Console.ReadLine());
            var discout = int.Parse(Console.ReadLine());

            var moneyFlight = 6 * (monyeForGoing + monyeForGoingBack);
            var moneyFlightTotal = moneyFlight - discout * moneyFlight / 100;
            var moneyForMaches = 6 * matches * billet;

            Console.WriteLine($"Total sum: {moneyForMaches + moneyFlightTotal:f2} lv.");
            Console.WriteLine($"Each friend has to pay {(moneyForMaches + moneyFlightTotal) / 6:f2} lv.");
        }
    }
}
