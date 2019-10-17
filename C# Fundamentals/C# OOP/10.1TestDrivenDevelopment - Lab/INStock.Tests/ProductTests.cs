namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectValue()
        {
            var label = "SSD";
            var price = 12.34m;
            var quantity = 3;
            IProduct product = new Product(label, price, quantity);

            Assert.AreEqual(label, product.Label);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(quantity, product.Quantity);
        }

        [Test]
        public void Constructor_InvalidLabel_ShouldThrowArgumentNullException()
        {
            string invalidLabel = null;
            var price = 12.34m;
            var quantity = 3;
            Assert.Throws<ArgumentNullException>(()=> new Product(invalidLabel, price, quantity));
        }

        [Test]
        public void Constructor_InvalidPrice_ShouldThrowArgumentException()
        {
            string label = "HDD";
            var invalidPrice = -1m;
            var quantity = 3;
            Assert.Throws<ArgumentException>(() => new Product(label, invalidPrice, quantity));
        }

        [Test]
        public void Constructor_InvalidQuantity_ShouldThrowArgumentException()
        {
            string label = "HDD";
            var price = 12.34m;
            var invalidQuantity = -1;
            Assert.Throws<ArgumentException>(() => new Product(label, price, invalidQuantity));
        }
    }
}