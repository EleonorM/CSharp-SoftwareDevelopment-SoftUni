using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Count_ShouldReturnProperValue()
        {
            var data = new Database.Database(1, 2, 3);
            var expected = 3;

            var actual = data.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationException_WhenArrayIsBiggerThan16()
        {
            var data = new Database.Database(Enumerable.Range(1, 16).ToArray());

            Assert.Throws<InvalidOperationException>(() => data.Add(1));
        }

        [Test]
        public void Add_ShouldIncreaseCount()
        {
            var data = new Database.Database(Enumerable.Range(1, 10).ToArray());
            var expected = 11;
            data.Add(22);

            var actual = data.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Remove_ShouldThrowInvalidOperationException_WhenDataIsEmpty()
        {
            var data = new Database.Database();

            Assert.Throws<InvalidOperationException>(() => data.Remove());
        }

        [Test]
        public void Remove_ShouldDecreaseCount()
        {
            var data = new Database.Database(Enumerable.Range(1, 10).ToArray());
            var expected = 9;
            data.Remove();

            var actual = data.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Fetch_ShouldReturnProperArray()
        {
            var data = new Database.Database(1, 2, 3);
            var expected = new int[] { 1, 2, 3 };

            var actual = data.Fetch();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}