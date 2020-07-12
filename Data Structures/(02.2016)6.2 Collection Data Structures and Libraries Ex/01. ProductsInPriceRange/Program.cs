namespace _01._ProductsInPriceRange
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main()
        {
            var bag = new OrderedBag<Product>();
            var linesToRead = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesToRead; i++)
            {
                var inputParts = Console.ReadLine().Split(" ");
                var productName = inputParts[0];
                var productPrice = decimal.Parse(inputParts[1]);
                bag.Add(new Product(productName, productPrice));
            }

            var inputRange = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
            var fromRange = inputRange[0];
            var toRange = inputRange[1];

            var fromProduct = bag.FindAll(x => x.Price >= fromRange && x.Price <= toRange);

            foreach (var product in fromProduct)
            {
                Console.WriteLine($"{product.Price} {product.Name}");
            }
        }
    }
}
