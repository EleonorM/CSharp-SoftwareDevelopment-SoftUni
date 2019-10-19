namespace _04._ListOfProducts
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();

            for (int i = 0; i < count; i++)
            {
                var product = Console.ReadLine();
                products.Add(product);
            }
            products.Sort();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }
    }
}
