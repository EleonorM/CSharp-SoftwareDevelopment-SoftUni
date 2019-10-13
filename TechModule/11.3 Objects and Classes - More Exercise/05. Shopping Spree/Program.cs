namespace _05._Shopping_Spree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var peopleInput = Console.ReadLine().Split(";");
            var people = new List<Person>();
            for (int i = 0; i < peopleInput.Length; i++)
            {
                var peopleSplit = peopleInput[i].Split("=");
                var name = peopleSplit[0];
                var money = int.Parse(peopleSplit[1]);
                var person = new Person();
                person.Name = name;
                person.Money = money;
                people.Add(person);
            }

            var productsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            var productsList = new List<Product>();
            for (int i = 0; i < productsInput.Length; i++)
            {
                var productsSplit = productsInput[i].Split("=");
                var name = productsSplit[0];
                var cost = int.Parse(productsSplit[1]);
                var product = new Product();
                product.Name = name;
                product.Cost = cost;
                productsList.Add(product);
            }

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "END")
                {
                    break;
                }
                var personName = input[0];
                var productName = input[1];
                var productPrice = 0;
                var productIndex = 0;
                foreach (var product in productsList)
                {
                    if (product.Name == productName)
                    {
                        productPrice = product.Cost;
                        productIndex = productsList.IndexOf(product);
                    }
                }

                foreach (var person in people)
                {
                    if (person.Name == personName)
                    {
                        if (person.Money >= productPrice)
                        {
                            person.Money = person.Money - productPrice;
                            person.Products.Add(productsList[productIndex]);
                            Console.WriteLine($"{personName} bought {productName}");
                        }
                        else
                        {
                            Console.WriteLine($"{personName} can't afford {productName}");
                        }
                    }
                }
            }

            foreach (var person in people)
            {
                if (person.Products.Count <= 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.Write($"{person.Name} -");
                    for (int i = 0; i < person.Products.Count; i++)
                    {
                        if (i == person.Products.Count - 1)
                        {
                            Console.Write($" {person.Products[i].Name}");
                        }
                        else
                        {
                            Console.Write($" {person.Products[i].Name},");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        class Person
        {
            public string Name;
            public int Money;
            public List<Product> Products;

            public Person()
            {
                Products = new List<Product>();
            }
        }

        class Product
        {
            public string Name;
            public int Cost;
        }
    }
}
