using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ShouldThhrowArgumentException_WhenAddedMoreThan16People()
        {
            var person1 = new Person(1, "Test1");
            var person2 = new Person(2, "Test2");
            var person3 = new Person(3, "Test3");
            var person4 = new Person(4, "Test4");
            var person5 = new Person(5, "Test5");
            var person6 = new Person(6, "Test6");
            var person7 = new Person(7, "Test7");
            var person8 = new Person(8, "Test8");
            var person9 = new Person(9, "Test9");
            var person10 = new Person(10, "Test10");
            var person11 = new Person(11, "Test11");
            var person12 = new Person(12, "Test12");
            var person13 = new Person(13, "Test13");
            var person14 = new Person(14, "Test14");
            var person15 = new Person(15, "Test15");
            var person16 = new Person(16, "Test16");
            var person17 = new Person(17, "Test17");
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(person1, person2, person3, person4, person5, person6, person7, person8, person9, person10, person11, person12, person13, person14, person15, person16, person17));
        }

        [Test]
        public void Constructor_ShouldIncreaseCount()
        {
            var person1 = new Person(1, "Test1");
            var person2 = new Person(2, "Test2");
            var person3 = new Person(3, "Test3");
            var person4 = new Person(4, "Test4");
            var person5 = new Person(5, "Test5");
            var person6 = new Person(6, "Test6");
            var person7 = new Person(7, "Test7");
            var person8 = new Person(8, "Test8");
            var person9 = new Person(9, "Test9");
            var data = new ExtendedDatabase.ExtendedDatabase(person1, person2, person3, person4, person5, person6, person7, person8, person9);

            var expected = 9;
            var actual = data.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Count_ShouldReturnProperValue()
        {
            var testId = 1;
            var testUserName = "Test";
            var person = new Person(testId, testUserName);
            var data = new ExtendedDatabase.ExtendedDatabase(person);
            var expected = 1;

            var actual = data.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_ShouldThhrowArgumentException_WhenAddedMoreThan16People()
        {
            var person1 = new Person(1, "Test1");
            var person2 = new Person(2, "Test2");
            var person3 = new Person(3, "Test3");
            var person4 = new Person(4, "Test4");
            var person5 = new Person(5, "Test5");
            var person6 = new Person(6, "Test6");
            var person7 = new Person(7, "Test7");
            var person8 = new Person(8, "Test8");
            var person9 = new Person(9, "Test9");
            var person10 = new Person(10, "Test10");
            var person11 = new Person(11, "Test11");
            var person12 = new Person(12, "Test12");
            var person13 = new Person(13, "Test13");
            var person14 = new Person(14, "Test14");
            var person15 = new Person(15, "Test15");
            var person16 = new Person(16, "Test16");
            var person17 = new Person(17, "Test17");
            var data = new ExtendedDatabase.ExtendedDatabase(person1, person2, person3, person4, person5, person6, person7, person8, person9, person10, person11, person12, person13, person14, person15, person16);

            Assert.Throws<InvalidOperationException>(() => data.Add(person17));
        }

        [Test]
        public void Add_ShouldIncreaseCount()
        {
            var person1 = new Person(1, "Test1");
            var person2 = new Person(2, "Test2");
            var data = new ExtendedDatabase.ExtendedDatabase(person1, person2);

            var expected = 2;
            var actual = data.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_ShouldIThrowInvalidOperationException_WhenSameUserName()
        {
            var person1 = new Person(1, "Test1");
            var person2 = new Person(2, "Test1");
            var data = new ExtendedDatabase.ExtendedDatabase(person1);

            Assert.Throws<InvalidOperationException>(() => data.Add(person2));
        }

        [Test]
        public void Add_ShouldIThrowInvalidOperationException_WhenSameId()
        {
            var person1 = new Person(1, "Test1");
            var person2 = new Person(1, "Test2");
            var data = new ExtendedDatabase.ExtendedDatabase(person1);

            Assert.Throws<InvalidOperationException>(() => data.Add(person2));
        }

        [Test]
        public void Remove_ShouldThrowInvalidOperationException_WhenDataIsEmpty()
        {
            var data = new ExtendedDatabase.ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => data.Remove());
        }

        [Test]
        public void Remove_ShouldDecreaseCount()
        {
            var person1 = new Person(1, "Test1");
            var person2 = new Person(2, "Test2");
            var data = new ExtendedDatabase.ExtendedDatabase(person1, person2);

            data.Remove();

            var expected = 1;
            var actual = data.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindByUsername_ShouldArgumentNullException_WhenGivenNullName()
        {
            var person1 = new Person(1, "Test1");
            var person2 = new Person(2, "Test2");
            var data = new ExtendedDatabase.ExtendedDatabase(person1, person2);

            string username = null;

            Assert.Throws<ArgumentNullException>(() => data.FindByUsername(username));
        }

        [Test]
        public void FindByUsername_ShouldInvalidOperationException_WhenGivenNotExistent()
        {
            var person1 = new Person(1, "Test1");
            var data = new ExtendedDatabase.ExtendedDatabase(person1);

            string username = "Test3";

            Assert.Throws<InvalidOperationException>(() => data.FindByUsername(username));
        }

        [Test]
        public void FindByUsername_ShouldReturnProperPerson()
        {
            var person1 = new Person(1, "Test1");
            var data = new ExtendedDatabase.ExtendedDatabase(person1);

            string username = "Test1";
            var searched = data.FindByUsername(username);
            Assert.AreEqual(person1, searched);
        }

        [Test]
        public void FindById_ShouldArgumentNullException_WhenIdBelow0()
        {
            var person1 = new Person(1, "Test1");
            var data = new ExtendedDatabase.ExtendedDatabase(person1);

            var id = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => data.FindById(id));
        }

        [Test]
        public void FindById_ShouldInvalidOperationException_WhenGivenNotExistent()
        {
            var person1 = new Person(1, "Test1");
            var data = new ExtendedDatabase.ExtendedDatabase(person1);

            var id = 2;

            Assert.Throws<InvalidOperationException>(() => data.FindById(id));
        }

        [Test]
        public void FindById_ShouldReturnProperPerson()
        {
            var person1 = new Person(1, "Test1");
            var data = new ExtendedDatabase.ExtendedDatabase(person1);

            var username = 1;
            var searched = data.FindById(username);
            Assert.AreEqual(person1, searched);
        }
    }
}