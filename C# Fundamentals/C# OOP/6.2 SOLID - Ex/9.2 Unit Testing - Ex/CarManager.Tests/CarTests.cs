using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ShoulSetProperValues()
        {
            string make = "TestMake";
            string model = "TestModel";
            double fuelConsumption = 5;
            double fuelCapacity = 10;
            double fuelAmount = 0;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(fuelAmount, car.FuelAmount);
        }

        [Test]
        public void Constructor_ShoulThrowArgumentException_WhenMakeIsNullOrEmpty()
        {
            string make = null;
            string model = "TestModel";
            double fuelConsumption = 5;
            double fuelCapacity = 10;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Constructor_ShoulThrowArgumentException_WhenModelIsNullOrEmpty()
        {
            string make = "TestMake";
            string model = null;
            double fuelConsumption = 5;
            double fuelCapacity = 10;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Constructor_ShoulThrowArgumentException_WhenFuelConsumptionValueLowerThan0()
        {
            string make = "TestMake";
            string model = "TestModel";
            double fuelConsumption = 0;
            double fuelCapacity = 10;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Constructor_ShoulThrowArgumentException_WhenFuelCapacityValueLowerThanOrEqual0()
        {
            string make = "TestMake";
            string model = "TestModel";
            double fuelConsumption = 5;
            double fuelCapacity = 0;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Refuel_ShouldThrowArgumentException_WhenFuelToRefuelBelow0()
        {
            string make = "TestMake";
            string model = "TestModel";
            double fuelConsumption = 5;
            double fuelCapacity = 10;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            var fuelToRefuel = 0;

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [Test]
        public void Refuel_ShouldIncreaseAmount()
        {
            string make = "TestMake";
            string model = "TestModel";
            double fuelConsumption = 5;
            double fuelCapacity = 10;
            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            var fuelToRefuel = 9;
            car.Refuel(fuelToRefuel);
            var actual = car.FuelAmount;
            var expected = 9;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Refuel_WithAmountLessThanOrEqualToCapacity()
        {
            string make = "TestMake";
            string model = "TestModel";
            double fuelConsumption = 5;
            double fuelCapacity = 10;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            var fuelToRefuel = 11;
            car.Refuel(fuelToRefuel);
            var actual = car.FuelAmount;
            var expected = 10;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Drive_ShouldThrowInvalidOperationException_WhenFuelNeededIsBiggerThanFuelAmount()
        {
            string make = "TestMake";
            string model = "TestModel";
            double fuelConsumption = 5;
            double fuelCapacity = 10;

            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            var fuelToRefuel = 3;
            car.Refuel(fuelToRefuel);
            var kmDistance = 1000;


            Assert.Throws<InvalidOperationException>(() => car.Drive(kmDistance));
        }

        [Test]
        public void Drive_ShouldReduceFuelAmount()
        {
            string make = "TestMake";
            string model = "TestModel";
            double fuelConsumption = 5;
            double fuelCapacity = 10;
            var car = new Car(make, model, fuelConsumption, fuelCapacity);
            var fuelToRefuel = 7;
            car.Refuel(fuelToRefuel);

            var kmDistance = 100;
            car.Drive(kmDistance);
            var expected = 2;
            var actual = car.FuelAmount;

            Assert.AreEqual(expected, actual);
        }
    }
}