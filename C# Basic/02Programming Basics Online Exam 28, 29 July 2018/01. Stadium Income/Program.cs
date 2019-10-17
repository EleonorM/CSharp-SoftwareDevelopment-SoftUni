namespace _01.Stadium_Income
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var sectors = int.Parse(Console.ReadLine());
            var capacity = int.Parse(Console.ReadLine());
            var billetPrice = double.Parse(Console.ReadLine());

            var moneyForSector = capacity * billetPrice / sectors;
            var moneyForCharity = (capacity * billetPrice - (moneyForSector * 0.75)) / 8;
            Console.WriteLine($"Total income - {capacity * billetPrice:f2} BGN");
            Console.WriteLine($"Money for charity - {moneyForCharity:f2} BGN");
        }
    }
}
