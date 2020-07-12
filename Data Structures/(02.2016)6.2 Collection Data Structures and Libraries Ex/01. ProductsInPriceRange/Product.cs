namespace _01._ProductsInPriceRange
{
    using System;

    public class Product : IComparable
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public int CompareTo(object obj)
        {
            var other = (Product)obj;

            return Price.CompareTo(other.Price);
        }
    }
}
