namespace _02.Beer_And_Chips
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var fanName = Console.ReadLine();
            var budget = double.Parse(Console.ReadLine());
            var beers = int.Parse(Console.ReadLine());
            var chips = int.Parse(Console.ReadLine());
            var moneyBeers = beers * 1.2;
            var moneyChips = Math.Ceiling(moneyBeers * 0.45 * chips);
            if (moneyBeers + moneyChips <= budget)
            {
                Console.WriteLine($"{fanName} bought a snack and has {budget - moneyBeers - moneyChips:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"{fanName} needs {Math.Abs(budget - moneyBeers - moneyChips):f2} more leva!");
            }
        }
    }
}
