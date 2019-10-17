namespace _06.Charity_Campaign
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var days = int.Parse(Console.ReadLine());
            var bakers = int.Parse(Console.ReadLine());
            var cakes = int.Parse(Console.ReadLine());
            var waffles = int.Parse(Console.ReadLine());
            var pancakes = int.Parse(Console.ReadLine());

            var cakesCost = cakes * 45.0;
            var wafflesCost = waffles * 5.8;
            var pancakesCost = pancakes * 3.2;
            Console.WriteLine("{0:0.00}", (cakesCost + wafflesCost + pancakesCost) * bakers * days * (1 - 1 / 8.0));
        }
    }
}
