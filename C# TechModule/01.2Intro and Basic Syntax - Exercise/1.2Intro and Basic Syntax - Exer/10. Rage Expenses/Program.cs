using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            double moneyLost = 0;

                moneyLost += lostGamesCount/2 * headsetPrice;
                moneyLost += lostGamesCount / 3 * mousePrice;
                moneyLost += lostGamesCount / 6 * keyboardPrice;
                moneyLost += lostGamesCount / 12 * displayPrice;

            Console.WriteLine($"Rage expenses: {moneyLost:f2} lv.");
        }
    }
}
