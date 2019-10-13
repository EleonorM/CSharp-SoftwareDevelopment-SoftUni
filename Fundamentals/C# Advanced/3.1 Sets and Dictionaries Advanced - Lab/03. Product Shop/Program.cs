namespace _03._Product_Shop
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Revision")
                {
                    break;
                }

                var line = input.Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
                var shop = line[0];
                var product = line[1];
                var price = double.Parse(line[2]);
                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }

                shops[shop][product] = price;
            }

            foreach (var kvp in shops)
            {
                var shop = kvp.Key;
                var products = kvp.Value;

                Console.WriteLine($"{shop}->");
                foreach (var kvpProd in products)
                {
                    Console.WriteLine($"Product: {kvpProd.Key}, Price: {kvpProd.Value}");
                }
            }
        }
    }
}
