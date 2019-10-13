namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftParkTest
    {
        private SoftPark parking;
        [SetUp]
        public void Setup()
        {
            parking = new SoftPark();
        }

        [Test]
        [TestCase("A1")]
        [TestCase("A2")]
        [TestCase("A3")]
        [TestCase("A4")]
        [TestCase("B1")]
        [TestCase("B2")]
        [TestCase("B3")]
        [TestCase("B4")]
        [TestCase("C1")]
        [TestCase("C2")]
        [TestCase("C3")]
        [TestCase("C4")]
        public void Constructor_SetProperKeys(string parkingSpot)
        {
            Assert.That(parking.Parking.ContainsKey(parkingSpot));
        }

        [Test]
        public void ParkCar_ShouldThrowArgumentException_DoesNotContainParkSpot()
        {
            var car = new Car("TestMake", "TestRegistarionNumber");
            var parkingSpot = "A9";

            Assert.Throws<ArgumentException>(() => parking.ParkCar(parkingSpot, car));
        }

        [Test]
        public void ParkCar_ShouldThrowArgumentException_ParkSpotTaken()
        {
            var car1 = new Car("TestMake", "TestRegistarionNumber");
            var car2 = new Car("TestMake1", "TestRegistarionNumber1");
            var parkingSpot = "A1";
            parking.ParkCar(parkingSpot, car1);

            Assert.Throws<ArgumentException>(() => parking.ParkCar(parkingSpot, car2));
        }

        [Test]
        public void ParkCar_ShouldThrowInvalidOperationException_ParkSameCar()
        {
            var car = new Car("TestMake", "TestRegistarionNumber");
            var parkingSpot = "A1";
            var parkingSpot2 = "A2";
            parking.ParkCar(parkingSpot, car);

            Assert.Throws<InvalidOperationException>(() => parking.ParkCar(parkingSpot2, car));
        }

        [Test]
        public void ParkCar_ShouldAddCarToParking()
        {
            var parkingSpot = "A1";
            var expected = new Car("TestMake", "TestRegistarionNumber");

            parking.ParkCar(parkingSpot, expected);

            var actual = parking.Parking[parkingSpot];
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveCar_ShouldThrowArgumentException_DoesNotContainParkSpot()
        {
            var car = new Car("TestMake", "TestRegistarionNumber");
            var parkingSpot = "A9";

            Assert.Throws<ArgumentException>(() => parking.RemoveCar(parkingSpot, car));
        }

        [Test]
        public void RemoveCar_ShouldThrowArgumentException_CarIsNotParkedOnTheSpot()
        {
            var car = new Car("TestMake", "TestRegistarionNumber");
            var car2 = new Car("TestMake1", "TestRegistarionNumber1");
            var parkingSpot = "A1";

            parking.ParkCar(parkingSpot, car);

            Assert.Throws<ArgumentException>(() => parking.RemoveCar(parkingSpot, car2));
        }

        [Test]
        public void RemoveCar_ShouldRemoveCarFromParking()
        {
            var parkingSpot = "A1";
            var car = new Car("TestMake", "TestRegistarionNumber");
            parking.ParkCar(parkingSpot, car);
            parking.RemoveCar(parkingSpot, car);
            Car expected = null;

            var actual = parking.Parking[parkingSpot];
            Assert.AreEqual(expected, actual);
        }
    }
}