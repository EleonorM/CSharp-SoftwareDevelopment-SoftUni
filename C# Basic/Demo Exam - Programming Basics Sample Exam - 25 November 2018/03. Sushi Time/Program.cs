namespace _03.Sushi_Time
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var typeSushi = Console.ReadLine();
            var restaurant = Console.ReadLine();
            var plate = int.Parse(Console.ReadLine());
            var order = Console.ReadLine();
            var price = 0.0;
            if (restaurant == "Sushi Zone")
            {
                switch (typeSushi)
                {
                    case "sashimi":
                        price = 4.99;
                        break;
                    case "maki":
                        price = 5.29;
                        break;
                    case "uramaki":
                        price = 5.99;
                        break;
                    case "temaki":
                        price = 4.29;
                        break;
                    default:
                        break;
                }
            }
            else if (restaurant == "Sushi Time")
            {
                switch (typeSushi)
                {
                    case "sashimi":
                        price = 5.49;
                        break;
                    case "maki":
                        price = 4.69;
                        break;
                    case "uramaki":
                        price = 4.49;
                        break;
                    case "temaki":
                        price = 5.19;
                        break;
                    default:
                        break;
                }
            }
            else if (restaurant == "Sushi Bar")
            {
                switch (typeSushi)
                {
                    case "sashimi":
                        price = 5.25;
                        break;
                    case "maki":
                        price = 5.55;
                        break;
                    case "uramaki":
                        price = 6.25;
                        break;
                    case "temaki":
                        price = 4.75;
                        break;
                    default:
                        break;
                }

            }
            else if (restaurant == "Asian Pub")
            {
                switch (typeSushi)
                {
                    case "sashimi":
                        price = 4.5;
                        break;
                    case "maki":
                        price = 4.8;
                        break;
                    case "uramaki":
                        price = 5.5;
                        break;
                    case "temaki":
                        price = 5.5;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine($"{restaurant} is invalid restaurant!");
                return;
            }

            var sum = price * plate;
            if (order == "Y")
            {
                sum = sum + 0.2 * sum;
            }

            Console.WriteLine($"Total price: {Math.Ceiling(sum)} lv.");
        }
    }
}
