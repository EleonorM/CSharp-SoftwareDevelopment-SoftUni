namespace _05.Fan_Shop
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var budget = int.Parse(Console.ReadLine());
            var count = int.Parse(Console.ReadLine());
            var moneySpend = 0;
            for (int i = 0; i < count; i++)
            {
                var subject = Console.ReadLine();
                switch (subject)
                {
                    case "hoodie": moneySpend += 30; break;
                    case "keychain": moneySpend += 4; break;
                    case "T-shirt": moneySpend += 20; break;
                    case "flag": moneySpend += 15; break;
                    case "sticker": moneySpend += 1; break;
                    default:
                        break;
                }
            }

            if (budget >= moneySpend)
            {
                Console.WriteLine($"You bought {count} items and left with {budget - moneySpend} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {moneySpend - budget} more lv.");
            }
        }
    }
}
