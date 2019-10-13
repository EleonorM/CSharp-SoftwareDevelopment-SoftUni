namespace _06.Fishing_Boat
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var budget = int.Parse(Console.ReadLine());
            var season = Console.ReadLine().ToLower();
            var fisherman = int.Parse(Console.ReadLine());
            var price = 0.00;

            if (season == "spring")
            {
                price = 3000;
            }
            else if (season == "summer" || season == "autumn")
            {
                price = 4200;
            }
            else if (season == "winter")
            {
                price = 2600;
            }

            if (fisherman <= 6)
            {
                price -= 0.1 * price;
            }
            else if (fisherman <= 11)
            {
                price -= 0.15 * price;
            }
            else
            {
                price -= 0.25 * price;
            }

            if (fisherman % 2 == 0 && season != "autumn")
            {
                price -= 0.05 * price;
            }

            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {budget - price:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(budget - price):f2} leva.");
            }
        }
    }
}
