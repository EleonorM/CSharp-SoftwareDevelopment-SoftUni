namespace INStock.Models
{
    using INStock.Contracts;
    using System;

    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label
        {
            get
            {
                return label;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                label = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                price = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                quantity = value;
            }
        }

        public int CompareTo(IProduct other)
        {
            return this.Label.CompareTo(other.Label);
        }
    }
}
