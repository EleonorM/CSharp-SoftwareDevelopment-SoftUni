namespace _07.Alcohol_Market
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var wiskeyCost = double.Parse(Console.ReadLine());
            var beerLitters = double.Parse(Console.ReadLine());
            var wineLitters = double.Parse(Console.ReadLine());
            var rakiaLitters = double.Parse(Console.ReadLine());
            var wiskeyLitters = double.Parse(Console.ReadLine());

            var rakiaCost = wiskeyCost / 2.0;
            var wineCost = rakiaCost - 0.4 * rakiaCost;
            var beerCost = rakiaCost - 0.8 * rakiaCost;
            Console.WriteLine("{0:0.00}", (wiskeyCost * wiskeyLitters) + (beerCost * beerLitters) + (rakiaCost * rakiaLitters) + (wineCost * wineLitters));
        }
    }
}
