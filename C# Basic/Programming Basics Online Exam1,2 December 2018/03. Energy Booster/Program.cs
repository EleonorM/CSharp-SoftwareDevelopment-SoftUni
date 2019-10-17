namespace _03.Energy_Booster
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var fruit = Console.ReadLine();
            var size = Console.ReadLine();
            var count = int.Parse(Console.ReadLine());
            double price = 0.0;

            if (size == "small")
            {
                switch (fruit)
                {
                    case "Watermelon": price = 56; break;
                    case "Mango": price = 36.66; break;
                    case "Pineapple": price = 42.1; break;
                    case "Raspberry": price = 20; break;
                    default:
                        break;
                }

                price = price * 2;
            }
            else if (size == "big")
            {
                switch (fruit)
                {
                    case "Watermelon": price = 28.7; break;
                    case "Mango": price = 19.6; break;
                    case "Pineapple": price = 24.8; break;
                    case "Raspberry": price = 15.2; break;
                    default:
                        break;
                }

                price = price * 5;
            }

            double moneyNeeded = price * count;
            if (moneyNeeded >= 400 && moneyNeeded <= 1000)
            {
                moneyNeeded = moneyNeeded * 0.85;
            }
            else if (moneyNeeded > 1000)
            {
                moneyNeeded = moneyNeeded * 0.5;
            }

            Console.WriteLine($"{moneyNeeded:f2} lv.");
        }
    }
}
