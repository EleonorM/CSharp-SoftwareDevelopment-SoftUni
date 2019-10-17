namespace INStock.Models
{
    using INStock.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductStock : IProductStock
    {
        private readonly List<IProduct> products;

        public ProductStock()
        {
            this.products = new List<IProduct>();
        }

        public IProduct this[int index]
        {
            get
            {
                if (index > this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.products[index];
            }

            set
            {
                if (index > this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                if (index == this.Count)
                {
                    this.products.Add(value);
                }

                else
                    this.products[index] = value;
            }
        }

        public int Count => products.Count;

        public void Add(IProduct product)
        {
            var searchedProduct = this.products.FirstOrDefault(x => x.Label == product.Label);
            if (searchedProduct == null)
            {
                products.Add(product);
                return;
            }

            throw new InvalidOperationException("This item already exists!");
        }

        public bool Contains(IProduct product)
        {
            var searchedProduct = this.products.FirstOrDefault(x => x.Label == product.Label);
            if (searchedProduct != null)
            {
                return true;
            }

            return false;
        }

        public IProduct Find(int index)
        {
            if (this.Count <= index)
            {
                throw new IndexOutOfRangeException("The index is not in range.");
            }

            return this.products[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            return this.products.Where(x => x.Price == (decimal)price).ToList();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return this.products.Where(x => x.Quantity == quantity).ToList();
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            return this.products.Where(x => (x.Price >= (decimal)lo && x.Price <= (decimal)hi)).OrderByDescending(x => x.Price).ToList();
        }

        public IProduct FindByLabel(string label)
        {
            var searchedProduct = this.products.FirstOrDefault(x => x.Label == label);
            if (searchedProduct != null)
            {
                return searchedProduct;
            }

            throw new ArgumentException($"Product with label {label} does not excist.");
        }

        public IProduct FindMostExpensiveProduct()
        {
            return this.products.OrderByDescending(x => x.Price).FirstOrDefault();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var item in this.products)
            {
                yield return item;
            }
        }

        public bool Remove(IProduct product)
        {
            if (this.products.Contains(product))
            {
                this.products.Remove(product);
                return true;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
