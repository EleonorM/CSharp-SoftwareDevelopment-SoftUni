namespace _04.Wedding_Decoration
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var budget = double.Parse(Console.ReadLine());
            var price = 0.0;
            var spendMoney = 0.0;
            var baloonCount = 0;
            var candleCount = 0;
            var flowerCount = 0;
            var ribbonCount = 0;
            while (true)
            {
                var type = Console.ReadLine();
                if (type == "stop")
                {
                    Console.WriteLine($"Spend money: {spendMoney:f2}");
                    Console.WriteLine($"Money left: {budget - spendMoney:f2}");
                    break;
                }
                else if (budget - spendMoney <= 0)
                {
                    Console.WriteLine($"All money is spent!");
                    break;
                }

                var count = int.Parse(Console.ReadLine());
                switch (type)
                {
                    case "balloons":
                        price = 0.1;
                        baloonCount += count;
                        break;
                    case "flowers":
                        price = 1.5;
                        flowerCount += count;
                        break;
                    case "candles":
                        price = 0.5;
                        candleCount += count;
                        break;
                    case "ribbon":
                        price = 2;
                        ribbonCount += count;
                        break;
                    default:
                        break;
                }

                spendMoney += count * price;
            }

            Console.WriteLine($"Purchased decoration is {baloonCount} balloons, {ribbonCount} m ribbon, {flowerCount} flowers and {candleCount} candles.");
        }
    }
}
