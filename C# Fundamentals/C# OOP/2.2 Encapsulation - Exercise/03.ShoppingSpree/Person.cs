namespace _03.ShoppingSpree
{
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                Validator.ValidateName(value);
                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            set
            {
                Validator.ValidateMoney(value);
                this.money = value;
            }
        }

        public string AddProductToBag(Product product)
        {
            if (this.Money < product.Cost)
            {
                return $"{this.Name} can't afford {product.Name}";
            }

            this.Money -= product.Cost;
            this.products.Add(product);
            return $"{this.Name} bought {product.Name}";
        }

        public override string ToString()
        {
            if (this.products.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {string.Join(", ", this.products.Select(p => p.Name))}";
        }
    }
}
