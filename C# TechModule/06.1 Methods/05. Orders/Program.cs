namespace _05._Orders
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var product = Console.ReadLine();
            var count = int.Parse(Console.ReadLine());
            PrintPrice(product, count);
        }

        static void PrintPrice(string product, int count)
        {
            double price = 0;
            if (product == "coffee")
            {
                price = 1.5;
            }
            else if (product == "water")
            {
                price = 1;
            }
            else if (product == "coke")
            {
                price = 1.4;
            }
            else if (product == "snacks")
            {
                price = 2;
            }

            Console.WriteLine($"{price * count:f2}");
        }
    }
}
