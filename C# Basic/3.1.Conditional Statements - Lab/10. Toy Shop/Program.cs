namespace _10.Toy_Shop
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double priceHoliday = double.Parse(Console.ReadLine());
            double countPuzzel = double.Parse(Console.ReadLine());
            double countDoll = double.Parse(Console.ReadLine());
            double countBear = double.Parse(Console.ReadLine());
            double countMinion = double.Parse(Console.ReadLine());
            double countTruck = double.Parse(Console.ReadLine());
            double sum;

            sum = countPuzzel * 2.6 + countDoll * 3 + countBear * 4.1 + countMinion * 8.2 + countTruck * 2;
            if (countBear + countDoll + countMinion + countPuzzel + countTruck >= 50)
            {
                sum = sum - 0.25 * sum;
            }
            sum = sum - 0.1 * sum;

            if (sum >= priceHoliday)
            {
                Console.WriteLine($"Yes! {sum - priceHoliday:0.00} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {priceHoliday - sum:0.00} lv needed.");
            }
        }
    }
}
