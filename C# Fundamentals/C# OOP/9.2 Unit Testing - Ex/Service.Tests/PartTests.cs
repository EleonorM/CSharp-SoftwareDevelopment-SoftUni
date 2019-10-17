using NUnit.Framework;
using Service.Models.Parts;
using System;

namespace Tests
{
    public class PartTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenNameIsNullOrEmpty()
        {
            string name = null;
            var cost = 10.10m;

            Assert.Throws<ArgumentException>(() => new LaptopPart(name, cost));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenCostIsBelowOrEqualTo0()
        {
            var name = "TestName";
            var cost = 0;

            Assert.Throws<ArgumentException>(() => new LaptopPart(name, cost));
        }

        [Test]
        public void IsBroken_ShouldSetsCorrectly()
        {
            var name = "TestName";
            var cost = 10.10m;
            var isBroken = true;
            var laptopPart = new LaptopPart(name, cost, isBroken);

            laptopPart.Repair();

            var expected = false;
            Assert.AreEqual(expected, laptopPart.IsBroken);
        }

        [Test]
        public void Report_ShouldReturnCorrectValue()
        {
            var name = "TestName";
            var cost = 10.10m;
            var isBroken = true;
            var laptopPart = new LaptopPart(name, cost, isBroken);


            var expected = $"{laptopPart.Name} - {laptopPart.Cost:f2}$" + Environment.NewLine +
                $"Broken: {laptopPart.IsBroken}"; ;
            Assert.AreEqual(expected, laptopPart.Report());
        }

        [Test]
        public void LaptopPart_Constructor_ShouldSetValuesCorrectly()
        {
            var name = "TestName";
            var cost = 10.10m;
            var multiplyer = 1.5m;
            var laptopPart = new LaptopPart(name, cost);

            Assert.AreEqual(name, laptopPart.Name);
            Assert.AreEqual(cost * multiplyer, laptopPart.Cost);
            Assert.AreEqual(false, laptopPart.IsBroken);
        }

        [Test]
        public void LaptopPart_Constructor_ShouldSetValuesCorrectlyWithParameterIsBroken()
        {
            var name = "TestName";
            var cost = 10.10m;
            var isBroken = true;
            var multiplyer = 1.5m;
            var laptopPart = new LaptopPart(name, cost, isBroken);

            Assert.AreEqual(name, laptopPart.Name);
            Assert.AreEqual(cost * multiplyer, laptopPart.Cost);
            Assert.AreEqual(true, laptopPart.IsBroken);
        }

        [Test]
        public void PCPart_Constructor_ShouldSetValuesCorrectly()
        {
            var name = "TestName";
            var cost = 10.10m;
            var multiplyer = 1.2m;
            var pcPart = new PCPart(name, cost);

            Assert.AreEqual(name, pcPart.Name);
            Assert.AreEqual(cost * multiplyer, pcPart.Cost);
            Assert.AreEqual(false, pcPart.IsBroken);
        }

        [Test]
        public void PCPart_Constructor_ShouldSetValuesCorrectlyWithParameterIsBroken()
        {
            var name = "TestName";
            var cost = 10.10m;
            var isBroken = true;
            var multiplyer = 1.2m;
            var pcPart = new PCPart(name, cost, isBroken);

            Assert.AreEqual(name, pcPart.Name);
            Assert.AreEqual(cost * multiplyer, pcPart.Cost);
            Assert.AreEqual(true, pcPart.IsBroken);
        }

        [Test]
        public void PhonePart_Constructor_ShouldSetValuesCorrectly()
        {
            var name = "TestName";
            var cost = 10.10m;
            var multiplyer = 1.3m;
            var phonePart = new PhonePart(name, cost);

            Assert.AreEqual(name, phonePart.Name);
            Assert.AreEqual(cost * multiplyer, phonePart.Cost);
            Assert.AreEqual(false, phonePart.IsBroken);
        }

        [Test]
        public void PhonePart_Constructor_ShouldSetValuesCorrectlyWithParameterIsBroken()
        {
            var name = "TestName";
            var cost = 10.10m;
            var isBroken = true;
            var multiplyer = 1.3m;
            var phonePart = new PhonePart(name, cost, isBroken);

            Assert.AreEqual(name, phonePart.Name);
            Assert.AreEqual(cost * multiplyer, phonePart.Cost);
            Assert.AreEqual(true, phonePart.IsBroken);
        }
    }
}