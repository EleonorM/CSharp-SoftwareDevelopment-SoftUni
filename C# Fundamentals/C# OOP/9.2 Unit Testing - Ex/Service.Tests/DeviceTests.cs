using NUnit.Framework;
using Service.Models.Devices;
using Service.Models.Parts;
using System;
using System.Linq;

namespace Service.Tests
{
    public class DeviceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ShouldInitializeColletionOfParts()
        {
            var name = "TestName";
            var laptop = new Laptop(name);

            var expected = 0;
            Assert.AreEqual(expected, laptop.Parts.Count);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenMakeIsNullOrEmpty()
        {
            string name = null;
            Assert.Throws<ArgumentException>(() => new Laptop(name));
        }

        [Test]
        public void AddPart_ShouldThrowInvalidOperationException_WhenTryToAddSamePart()
        {
            var name = "TestName";
            var laptop = new Laptop(name);

            var namePart = "TestNamePart";
            var costPart = 10.10m;
            var namePart2 = "TestNamePart";
            var costPart2 = 9.10m;
            var laptopPart = new LaptopPart(namePart, costPart);
            var laptopPart2 = new LaptopPart(namePart2, costPart2);

            laptop.AddPart(laptopPart);

            Assert.Throws<InvalidOperationException>(() => laptop.AddPart(laptopPart2));
        }


        [Test]
        public void AddPart_ShouldAddPartCorrectly()
        {
            var name = "TestName";
            var laptop = new Laptop(name);

            var namePart = "TestNamePart";
            var costPart = 10.10m;
            var laptopPart = new LaptopPart(namePart, costPart);

            laptop.AddPart(laptopPart);

            var expected = 1;
            Assert.AreEqual(expected, laptop.Parts.Count);                
        }

        [Test]
        public void RemovePart_ShouldThrowArgumentException_WhenTheNameIsNullOrEmpty()
        {
            var name = "TestName";
            var laptop = new Laptop(name);

            var namePart = "TestNamePart";
            var costPart = 10.10m;
            var laptopPart = new LaptopPart(namePart, costPart);

            laptop.AddPart(laptopPart);

            string searchedNamePart = null;
            Assert.Throws<ArgumentException>(() => laptop.RemovePart(searchedNamePart));
        }

        [Test]
        public void RemovePart_ShouldThrowInvalidOperationException_WhenThePartDoesNotExist()
        {
            var name = "TestName";
            var laptop = new Laptop(name);

            var namePart = "TestNamePart";
            var costPart = 10.10m;
            var laptopPart = new LaptopPart(namePart, costPart);

            laptop.AddPart(laptopPart);

            var searchedNamePart = "WrongName";
            Assert.Throws<InvalidOperationException>(() => laptop.RemovePart(searchedNamePart));
        }

        [Test]
        public void RemovePart_ShouldRemovePartCorrectly()
        {
            var name = "TestName";
            var laptop = new Laptop(name);

            var namePart = "TestNamePart";
            var costPart = 10.10m;
            var laptopPart = new LaptopPart(namePart, costPart);
            laptop.AddPart(laptopPart);
            var searchedNamePart = "TestNamePart";

            laptop.RemovePart(searchedNamePart);

            var expected = 0;
            Assert.AreEqual(expected, laptop.Parts.Count);
        }

        [Test]
        public void RepairPart_ShouldThrowArgumentException_WhenTheNameIsNullOrEmpty()
        {
            var name = "TestName";
            var laptop = new Laptop(name);

            var namePart = "TestNamePart";
            var costPart = 10.10m;
            var laptopPart = new LaptopPart(namePart, costPart,true);

            laptop.AddPart(laptopPart);

            string searchedNamePart = null;
            Assert.Throws<ArgumentException>(() => laptop.RepairPart(searchedNamePart));
        }

        [Test]
        public void RepairPart_ShouldThrowInvalidOperationException_WhenThePartDoesNotExist()
        {
            var name = "TestName";
            var laptop = new Laptop(name);

            var namePart = "TestNamePart";
            var costPart = 10.10m;
            var laptopPart = new LaptopPart(namePart, costPart,true);

            laptop.AddPart(laptopPart);

            var searchedNamePart = "WrongName";
            Assert.Throws<InvalidOperationException>(() => laptop.RepairPart(searchedNamePart));
        }

        [Test]
        public void RepairPart_ShouldThrowInvalidOperationException_WhenThePartIsNotBroken()
        {
            var name = "TestName";
            var laptop = new Laptop(name);

            var namePart = "TestNamePart";
            var costPart = 10.10m;
            var laptopPart = new LaptopPart(namePart, costPart,false);

            laptop.AddPart(laptopPart);

            var searchedNamePart = "TestNamePart";
            Assert.Throws<InvalidOperationException>(() => laptop.RepairPart(searchedNamePart));
        }

        [Test]
        public void RepairPart_ShouldRepairPartsCorrectly()
        {
            var name = "TestName";
            var laptop = new Laptop(name);

            var namePart = "TestNamePart";
            var costPart = 10.10m;
            var laptopPart = new LaptopPart(namePart, costPart,true);

            laptop.AddPart(laptopPart);

            var searchedNamePart = "TestNamePart";
            laptop.RepairPart(searchedNamePart);

            var expected = false;
            Assert.AreEqual(expected, laptop.Parts.First(x => x.Name == searchedNamePart).IsBroken);
        }


        [Test]
        public void LaptopConstructor_ShouldSetCorrectValues()
        {
            var name = "TestName";
            var laptop = new Laptop(name);

            Assert.AreEqual(name, laptop.Make);
        }

        [Test]
        public void LaptopAddPart_ShouldThrowInvalidOperationException_WhenThePartIsNotCorrect()
        {
            var name = "TestName";
            var laptop = new Laptop(name);
            var namePart = "TestNamePart";
            var costPart = 10.10m;
            var pcPart = new PCPart(namePart, costPart, true);

            Assert.Throws<InvalidOperationException>(() => laptop.AddPart(pcPart));
        }

        [Test]
        public void PCConstructor_ShouldSetCorrectValues()
        {
            var name = "TestName";
            var pc = new PC(name);

            Assert.AreEqual(name, pc.Make);
        }

        [Test]
        public void PCAddPart_ShouldThrowInvalidOperationException_WhenThePartIsNotCorrect()
        {
            var name = "TestName";
            var pc = new PC(name);
            var namePart = "TestNamePart";
            var costPart = 10.10m;
            var latopPart = new LaptopPart(namePart, costPart, true);

            Assert.Throws<InvalidOperationException>(() => pc.AddPart(latopPart));
        }

        [Test]
        public void PhoneConstructor_ShouldSetCorrectValues()
        {
            var name = "TestName";
            var phone = new PC(name);

            Assert.AreEqual(name, phone.Make);
        }

        [Test]
        public void PhoneAddPart_ShouldThrowInvalidOperationException_WhenThePartIsNotCorrect()
        {
            var name = "TestName";
            var phone = new Phone(name);
            var namePart = "TestNamePart";
            var costPart = 10.10m;
            var latopPart = new LaptopPart(namePart, costPart, true);

            Assert.Throws<InvalidOperationException>(() => phone.AddPart(latopPart));
        }
    }
}
