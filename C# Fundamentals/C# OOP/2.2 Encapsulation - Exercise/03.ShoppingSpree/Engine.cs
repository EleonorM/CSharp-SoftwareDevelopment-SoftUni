namespace _03.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private List<Person> people;
        private List<Product> products;
        public void Run()
        {
            people = new List<Person>();
            products = new List<Product>();
            try
            {
                PersonInput();
                ProductInput();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "END")
                {
                    break;
                }
                var name = input[0];
                var product = input[1];
                var searchedProduct = products.FirstOrDefault(x => x.Name == product);
                Console.WriteLine(people.FirstOrDefault(x => x.Name == name).AddProductToBag(searchedProduct));
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }

        private void ProductInput()
        {
            var productInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productInput.Length; i++)
            {
                var productTokens = productInput[i].Split("=");
                var product = new Product(productTokens[0], decimal.Parse(productTokens[1]));
                products.Add(product);
            }
        }

        private void PersonInput()
        {
            var peopleInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < peopleInput.Length; i++)
            {
                var peopleTokens = peopleInput[i].Split("=");

                var person = new Person(peopleTokens[0], decimal.Parse(peopleTokens[1]));
                people.Add(person);
            }
        }
    }
}
