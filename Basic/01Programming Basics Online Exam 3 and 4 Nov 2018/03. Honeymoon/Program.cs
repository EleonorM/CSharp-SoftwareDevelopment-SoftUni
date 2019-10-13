namespace _03.Honeymoon
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var budget = decimal.Parse(Console.ReadLine());
            var city = Console.ReadLine();
            var nights = int.Parse(Console.ReadLine());

            decimal price = 0.0m;
            decimal priceFlight = 0.0m;
            switch (city)
            {
                case "Cairo":
                    price = 2 * 250;
                    priceFlight = 600;
                    break;
                case "Paris":
                    price = 2 * 150;
                    priceFlight = 350;
                    break;
                case "Lima":
                    price = 2 * 400;
                    priceFlight = 850;
                    break;
                case "New York":
                    price = 2 * 300;
                    priceFlight = 650;
                    break;
                case "Tokyo":
                    price = 2 * 350;
                    priceFlight = 700;
                    break;
                default:
                    break;
            }

            decimal sum = nights * price + priceFlight;
            if (nights <= 4)
            {
                if (city == "Cairo" || city == "New York")
                {
                    sum = sum - 0.03m * sum;
                }
            }
            else if (nights <= 9)
            {
                if (city == "Cairo" || city == "New York")
                {
                    sum = sum - 0.05m * sum;
                }
                else if (city == "Paris")
                {
                    sum = sum - 0.07m * sum;
                }
            }
            else if (nights <= 24)
            {
                if (city == "Tokyo" || city == "New York" || city == "Paris")
                {
                    sum = sum - 0.12m * sum;
                }
                else if (city == "Cairo")
                {
                    sum = sum - 0.1m * sum;
                }
            }
            else if (nights <= 49)
            {
                if (city == "Tokyo" || city == "Cairo")
                {
                    sum = sum - 0.17m * sum;
                }
                else if (city == "New York" || city == "Lima")
                {
                    sum = sum - 0.19m * sum;
                }
                else if (city == "Paris")
                {
                    sum = sum - 0.22m * sum;
                }
            }
            else if (nights >= 50)
            {
                sum = sum - 0.3m * sum;
            }

            if (budget - sum >= 0)
            {
                Console.WriteLine($"Yes! You have {(budget - sum):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(budget - sum):f2} leva.");
            }
        }
    }
}
