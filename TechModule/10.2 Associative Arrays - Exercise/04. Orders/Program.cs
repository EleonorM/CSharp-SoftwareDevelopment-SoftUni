namespace _04._Orders
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var products = new Dictionary<string, Product>();

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "buy")
                {
                    break;
                }

                var product = input[0];
                var price = double.Parse(input[1]);
                var quantity = int.Parse(input[2]);
                if (products.ContainsKey(product))
                {
                    products[product].Value += quantity;
                    products[product].Price = price;
                }
                else
                {
                    products[product] = new Product();
                    products[product].Value = quantity;
                    products[product].Price = price;
                }
            }

            foreach (var kvp in products)
            {
                Console.WriteLine($"{kvp.Key} -> { kvp.Value.Value * kvp.Value.Price:f2}");
            }
        }

        class Product
        {
            public double Price { get; set; }
            public int Value { get; set; }
        }
    }
}
