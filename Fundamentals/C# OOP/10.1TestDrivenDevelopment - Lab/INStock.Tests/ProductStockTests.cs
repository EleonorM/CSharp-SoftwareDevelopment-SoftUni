namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        [Test]
        public void ProductStock_Constructor_ShoulInitializeTheList()
        {
            var stock = new ProductStock();


            Assert.That(stock.Count == 0);
        }

        [Test]
        public void ProductStock_AddProductCorrectly()
        {
            var label1 = "Bread";
            var price1 = 10;
            var quantity1 = 10;
            var label2 = "Test1";
            var price2 = 10;
            var quantity2 = 10;
            var product = new Product(label1, price1, quantity1);
            var productToAdd = new Product(label2, price2, quantity2);
            var stock = new ProductStock();

            stock.Add(product);
            stock.Add(productToAdd);
            Assert.That(stock.Contains(product));
        }

        [Test]
        [TestCase("Bread", 10, 10)]
        [TestCase("Bread", 12, 10)]
        [TestCase("Bread", 10, 12)]
        [TestCase("Bread", 12, 12)]
        public void ProductStock_ShoulThrowInvalidOperationException_WhenAddedSameProduct(string name, decimal price, int quantity)
        {
            var label1 = "Bread";
            var price1 = 10;
            var quantity1 = 10;
            var product = new Product(label1, price1, quantity1);
            var productForCheking = new Product(name, price, quantity);
            var stock = new ProductStock();

            stock.Add(product);
            Assert.Throws<InvalidOperationException>(() => stock.Add(productForCheking));
        }

        [Test]
        public void ProductStock_ContainsAddedItem()
        {
            var label1 = "Bread";
            var price1 = 10;
            var quantity1 = 10;
            var product = new Product(label1, price1, quantity1);
            var stock = new ProductStock();

            stock.Add(product);
            Assert.That(stock.Contains(product));
        }

        [Test]
        public void ProductStock_CountWorkCorrectly()
        {
            var label1 = "Bread";
            var price1 = 10;
            var quantity1 = 10;
            var label2 = "Test1";
            var price2 = 10;
            var quantity2 = 10;
            var product = new Product(label1, price1, quantity1);
            var productToAdd = new Product(label2, price2, quantity2);
            var stock = new ProductStock();

            stock.Add(product);
            stock.Add(productToAdd);
            Assert.That(stock.Count == 2);
        }

        [Test]
        public void ProductStock_FindReturnsTheProduct()
        {
            var label1 = "Bread";
            var price1 = 10;
            var quantity1 = 10;
            var label2 = "Test1";
            var price2 = 10;
            var quantity2 = 10;
            var product = new Product(label1, price1, quantity1);
            var productToReturn = new Product(label2, price2, quantity2);
            var stock = new ProductStock();

            stock.Add(product);
            stock.Add(productToReturn);

            Assert.That(stock.Find(1) == productToReturn);
        }

        [Test]
        public void ProductStock_FindThrowsIndexOutOfRangeException_WhenInvalidIndex()
        {
            var label1 = "Bread";
            var price1 = 10;
            var quantity1 = 10;
            var label2 = "Test1";
            var price2 = 10;
            var quantity2 = 10;
            var product = new Product(label1, price1, quantity1);
            var productToReturn = new Product(label2, price2, quantity2);
            var stock = new ProductStock();

            stock.Add(product);
            stock.Add(productToReturn);

            Assert.Throws<IndexOutOfRangeException>(() => stock.Find(2));
        }

        [Test]
        public void ProductStock_FindsByLabelTheProduct()
        {
            var label1 = "Test";
            var price1 = 10;
            var quantity1 = 10;
            var product = new Product(label1, price1, quantity1);
            var stock = new ProductStock();

            stock.Add(product);

            Assert.That(stock.FindByLabel(label1) == product);
        }

        [Test]
        public void ProductStock_FindsByLabel_ThrowsArgumentExceptionWhenGvenFalseLabel()
        {
            var label1 = "Test";
            var price1 = 10;
            var quantity1 = 10;
            var product = new Product(label1, price1, quantity1);
            var stock = new ProductStock();

            stock.Add(product);

            Assert.Throws<ArgumentException>(() => stock.FindByLabel(label1));
        }

        [Test]
        public void ProductStocl_FindAllInPriceRangeReturnsOrderedSearchedCollection()
        {
            var startRange = 10;
            var endRange = 100;
            var product1 = new Product("Test1", 10, 10);
            var product2 = new Product("Test2", 120, 10);
            var product3 = new Product("Test3", 110, 10);
            var product4 = new Product("Test4", 15, 10);
            var product5 = new Product("Test5", 1000, 10);
            var stock = new ProductStock();

            stock.Add(product1);
            stock.Add(product2);
            stock.Add(product3);
            stock.Add(product4);
            stock.Add(product5);

            Assert.That(stock.FindAllInRange(startRange, endRange).All(x => x.Price <= endRange && x.Price >= startRange));
        }

        [Test]
        public void ProductStocl_FindAllByPriceReturnsSearchedCollection()
        {
            var searchedPrice = 1;
            var product1 = new Product("Test1", 10, 10);
            var product2 = new Product("Test2", 120, 10);
            var product3 = new Product("Test3", 10, 10);
            var product4 = new Product("Test4", 15, 10);
            var product5 = new Product("Test5", 1000, 10);
            var stock = new ProductStock();

            stock.Add(product1);
            stock.Add(product2);
            stock.Add(product3);
            stock.Add(product4);
            stock.Add(product5);

            Assert.That(stock.FindAllByPrice(searchedPrice).All(x => x.Price == searchedPrice));
        }

        [Test]
        public void ProductStocl_FindMostExpensiveProductsReturnsSearchedCollection()
        {
            var product1 = new Product("Test1", 10, 10);
            var product2 = new Product("Test2", 120, 10);
            var product3 = new Product("Test3", 10, 10);
            var product4 = new Product("Test4", 15, 10);
            var product5 = new Product("Test5", 1000, 10);
            var stock = new ProductStock();

            stock.Add(product1);
            stock.Add(product2);
            stock.Add(product3);
            stock.Add(product4);
            stock.Add(product5);

            Assert.AreEqual(stock.FindMostExpensiveProduct(), stock.OrderByDescending(x => x.Price).FirstOrDefault());
        }

        [Test]
        public void ProductStocl_FindAllByQuantityReturnsSearchedItem()
        {
            var searchedQuantity = 2;
            var product1 = new Product("Test1", 10, 10);
            var product2 = new Product("Test2", 120, 2);
            var product3 = new Product("Test3", 10, 5);
            var product4 = new Product("Test4", 15, 2);
            var product5 = new Product("Test5", 1000, 10);
            var stock = new ProductStock();

            stock.Add(product1);
            stock.Add(product2);
            stock.Add(product3);
            stock.Add(product4);
            stock.Add(product5);

            var filteredStock = stock.FindAllByQuantity(searchedQuantity);

            Assert.That(filteredStock.All(x => x.Quantity == searchedQuantity));
        }

        [Test]
        public void ProductStock_GetEnumerator_ReturnsAll()
        {
            var product1 = new Product("Test1", 10, 10);
            var product2 = new Product("Test2", 120, 2);
            var product3 = new Product("Test3", 10, 5);
            var product4 = new Product("Test4", 15, 2);
            var product5 = new Product("Test5", 1000, 10);
            var stock = new ProductStock();

            stock.Add(product1);
            stock.Add(product2);
            stock.Add(product3);
            stock.Add(product4);
            stock.Add(product5);


            IEnumerable weak = stock;
            var sequence = weak.Cast<Product>().Take(5).ToArray();
            CollectionAssert.AreEqual(sequence,
                new[] { product1, product2, product3, product4, product5 });

        }

        [Test]
        public void ProductStock_RemoveItem_Succsesfully()
        {
            var label1 = "Test";
            var price1 = 10;
            var quantity1 = 10;
            var product = new Product(label1, price1, quantity1);
            var stock = new ProductStock();

            stock.Add(product);

            Assert.That(stock.Remove(product) == true);
        }

        [Test]
        public void ProductStock_RemoveInvalidItem_ShouldReturnFalse()
        {
            var label1 = "Test";
            var price1 = 10;
            var quantity1 = 10;
            var product = new Product(label1, price1, quantity1);
            var stock = new ProductStock();

            stock.Add(product);
            IProduct invalidProduct = null;

            Assert.That(stock.Remove(invalidProduct) == false);
        }

        [Test]
        public void ProductStock_Set_InvalidIndex_ShouldReturnOutOfBoundryExcpetion()
        {
            var label1 = "Test";
            var price1 = 10;
            var quantity1 = 10;
            var product = new Product(label1, price1, quantity1);
            var stock = new ProductStock();

            Assert.Throws<IndexOutOfRangeException>(() => stock[stock.Count + 2] = product);
        }

        [Test]
        public void ProductStock_Set_ValidIndex_ShouldReturnOutOfBoundryExcpetion()
        {
            var label1 = "Test";
            var price1 = 10;
            var quantity1 = 10;
            var product = new Product(label1, price1, quantity1);
            var stock = new ProductStock();
            stock[0] = product;

            var actualProduct = stock[0];

            Assert.AreSame(product, actualProduct);
        }

        [Test]
        public void ProductStock_Get_ValidIndex_ShouldReturnValue()
        {
            var label1 = "Test";
            var price1 = 10;
            var quantity1 = 10;
            var product = new Product(label1, price1, quantity1);
            var stock = new ProductStock();
            stock.Add(product);

            var actualProduct = stock[0];

            Assert.AreSame(product, actualProduct);
        }

        [Test]
        public void ProductStock_Get_InvalidIndex_ShouldThrowOutOfRange()
        {
            var label1 = "Test";
            var price1 = 10;
            var quantity1 = 10;
            var product = new Product(label1, price1, quantity1);
            var stock = new ProductStock();
            stock.Add(product);

            IProduct productOutOfRane = null;

            Assert.Throws<IndexOutOfRangeException>(() => productOutOfRane = stock[2]);
        }

        [Test]
        public void ProductStock_CompareTo_ShouldReturnLabelWithGraterAsciiCode()
        {
            var greaterProductLabel = "Zoom";
            var greaterProductPrice = 12.34m;
            var greaterProductQuantity = 3;

            var smallerProductLabel = "Do";
            var smallerProductPrice = 10.34m;
            var smallerProductQuantity = 4;

            var greaterProduct = new Product(greaterProductLabel, greaterProductPrice, greaterProductQuantity);
            var smallerProduct = new Product(smallerProductLabel, smallerProductPrice, smallerProductQuantity);

            int actualResult = greaterProduct.CompareTo(smallerProduct);
            int expectedResult = 1;

            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
