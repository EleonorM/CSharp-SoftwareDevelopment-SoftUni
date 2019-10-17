namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        [Test]
        public void Constructor_ShouldInitializeCollection()
        {
            var make = "TestMake";
            var model = "TestModel";
            var phone = new Phone(make, model);

            var expected = 0;
            Assert.AreEqual(expected, phone.Count);
        }

        [Test]
        public void Constructor_ShouldReturnProperCount()
        {
            var make = "TestMake";
            var model = "TestModel";
            var phone = new Phone(make, model);

            var expected = 0;
            Assert.AreEqual(expected, phone.Count);
        }

        [Test]
        public void Constructor_ShouldSetPropreMake()
        {
            var make = "TestMake";
            var model = "TestModel";
            var phone = new Phone(make, model);

            Assert.AreEqual(make, phone.Make);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenMakeIsNullOrEmpty()
        {
            string make = null;
            var model = "TestModel";

            Assert.Throws<ArgumentException>(() => new Phone(make, model));
        }

        [Test]
        public void Constructor_ShouldSetPropreModel()
        {
            var make = "TestMake";
            var model = "TestModel";
            var phone = new Phone(make, model);

            Assert.AreEqual(model, phone.Model);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenModelIsNullOrEmpty()
        {
            var make = "TestMake";
            string model = null;

            Assert.Throws<ArgumentException>(() => new Phone(make, model));
        }

        [Test]
        public void AddContact_ShouldThrowInvalidOperationException_WhenPhonebookContainsContact()
        {

            var make1 = "TestMake1";
            var model1 = "TestModel1";
            var phone = new Phone(make1, model1);

            var nameContact1 = "TestName";
            var phoneNumber1 = "10";
            var phoneNumber2 = "20";
            phone.AddContact(nameContact1, phoneNumber1);

            Assert.Throws<InvalidOperationException>(() => phone.AddContact(nameContact1, phoneNumber2));
        }

        [Test]
        public void AddContact_ShouldAddContactCorrectly()
        {

            var make1 = "TestMake1";
            var model1 = "TestModel1";
            var phone = new Phone(make1, model1);

            var nameContact1 = "TestName";
            var phoneNumber1 = "10";
            phone.AddContact(nameContact1, phoneNumber1);

            var expected = 1;
            Assert.AreEqual(expected, phone.Count);
        }

        [Test]
        public void Call_ShouldThrowInvalidOperationException_WhenPhonebookDoesNotContainContact()
        {

            var make1 = "TestMake1";
            var model1 = "TestModel1";
            var phone = new Phone(make1, model1);

            var nameContact1 = "TestName1";
            var nameContact2 = "TestName2";
            var phoneNumber1 = "10";
            phone.AddContact(nameContact1, phoneNumber1);

            Assert.Throws<InvalidOperationException>(() => phone.Call(nameContact2));
        }

        [Test]
        public void Call_ShouldReturnProperMessage()
        {

            var make1 = "TestMake1";
            var model1 = "TestModel1";
            var phone = new Phone(make1, model1);

            var nameContact1 = "TestName1";
            var phoneNumber1 = "10";
            phone.AddContact(nameContact1, phoneNumber1);

            var actual = phone.Call(nameContact1);

            var expected = $"Calling {nameContact1} - {phoneNumber1}...";
            Assert.AreEqual(expected, actual);
        }
    }
}