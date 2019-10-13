namespace _02.Football_Kit
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var tshirtPrice = double.Parse(Console.ReadLine());
            var sumTillPrice = double.Parse(Console.ReadLine());

            var shortsPrice = 0.75 * tshirtPrice;
            var socksPrice = 0.2 * shortsPrice;
            var buttonsPrice = 2 * (shortsPrice + tshirtPrice);
            var moneyEquip = (shortsPrice + tshirtPrice + socksPrice + buttonsPrice) * 0.85;
            if (moneyEquip >= sumTillPrice)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {moneyEquip:f2} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {sumTillPrice - moneyEquip:f2} lv. more.");
            }
        }
    }
}
