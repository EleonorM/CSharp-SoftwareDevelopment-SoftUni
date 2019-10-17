namespace TheRace.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ShoudInitializieCollection()
        {
            var raceEntry = new RaceEntry();

            var expected = 0;
            Assert.AreEqual(expected, raceEntry.Counter);
        }

        [Test]
        public void Counter_ShoudReturnProperValue()
        {
            var raceEntry = new RaceEntry();

            var expected = 0;
            Assert.AreEqual(expected, raceEntry.Counter);
        }

        [Test]
        public void AddRider_ShoudThrowInvalidOperationException_WhenInvalidRider()
        {
            var raceEntry = new RaceEntry();
            UnitRider rider = null;


            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(rider));
        }

        [Test]
        public void AddRider_ShoudThrowInvalidOperationException_WhenRiderAlreadyExist()
        {
            var name = "TestName1";
            var motorcycle1 = new UnitMotorcycle("1", 100, 100);
            var motorcycle2 = new UnitMotorcycle("1", 100, 100);
            var raceEntry = new RaceEntry();
            UnitRider rider1 = new UnitRider(name, motorcycle1);
            UnitRider rider2 = new UnitRider(name, motorcycle2);
            raceEntry.AddRider(rider1);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(rider2));
        }

        [Test]
        public void AddRider_ShoudAddRiderCorrectly()
        {
            var name = "TestName1";
            var motorcycle1 = new UnitMotorcycle("1", 100, 100);
            var raceEntry = new RaceEntry();
            UnitRider rider1 = new UnitRider(name, motorcycle1);

            raceEntry.AddRider(rider1);

            var expected = 1;
            Assert.AreEqual(expected, raceEntry.Counter);
        }

        [Test]
        public void AddRider_ShoudRetutrnOutputCorrectly()
        {
            var name = "TestName1";
            var motorcycle1 = new UnitMotorcycle("1", 100, 100);
            var raceEntry = new RaceEntry();
            UnitRider rider1 = new UnitRider(name, motorcycle1);

            var actual = raceEntry.AddRider(rider1);

            var expected = $"Rider {name} added in race.";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateAverageHorsePower_ShoudThrowInvalidOperationException_WhenRiderAreLessThanMinParticipants()
        {
            var name = "TestName1";
            var name2 = "TestName2";
            var motorcycle1 = new UnitMotorcycle("1", 100, 100);
            var motorcycle2 = new UnitMotorcycle("1", 100, 100);
            var raceEntry = new RaceEntry();
            UnitRider rider1 = new UnitRider(name, motorcycle1);
            UnitRider rider2 = new UnitRider(name2, motorcycle2);
            raceEntry.AddRider(rider1);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_ShoudReturnAverageHorsePower()
        {
            var name = "TestName1";
            var name2 = "TestName2";
            var motorcycle1 = new UnitMotorcycle("1", 100, 100);
            var motorcycle2 = new UnitMotorcycle("1", 100, 100);
            var raceEntry = new RaceEntry();
            UnitRider rider1 = new UnitRider(name, motorcycle1);
            UnitRider rider2 = new UnitRider(name2, motorcycle2);
            raceEntry.AddRider(rider1);
            raceEntry.AddRider(rider2);

            var actual = raceEntry.CalculateAverageHorsePower();

            List<UnitRider> riders = new List<UnitRider>() { rider1, rider2 };
            var expected = riders
               .Select(x => x.Motorcycle.HorsePower)
               .Average();

            Assert.AreEqual(expected, actual);
        }
    }
}