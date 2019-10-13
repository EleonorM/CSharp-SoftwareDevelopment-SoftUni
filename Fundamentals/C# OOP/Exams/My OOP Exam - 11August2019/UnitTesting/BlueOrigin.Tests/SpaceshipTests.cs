namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        [Test]
        public void Constructor_ShouldInitializeCollection()
        {
            var name = "TestName";
            var capacity = 10;
            var spaceship = new Spaceship(name, capacity);

            var expexted = 0;
            Assert.AreEqual(expexted, spaceship.Count);
        }

        [Test]
        public void Constructor_ShouldInitializeCorrecctName()
        {
            var name = "TestName";
            var capacity = 10;
            var spaceship = new Spaceship(name, capacity);

            Assert.AreEqual(name, spaceship.Name);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenNameIsNullOrEmpty()
        {
            string name = null;
            var capacity = 10;

            Assert.Throws<ArgumentNullException>(() => new Spaceship(name, capacity));
        }

        [Test]
        public void Constructor_ShouldInitializeCorrecctCapacity()
        {
            var name = "TestName";
            var capacity = 10;
            var spaceship = new Spaceship(name, capacity);

            Assert.AreEqual(capacity, spaceship.Capacity);

        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenCapacityIsBelow0()
        {
            string name = "TestName";
            var capacity = -1;

            Assert.Throws<ArgumentException>(() => new Spaceship(name, capacity));
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationException_WhenCapacityIsEqualToCount()
        {
            string name = "TestName";
            var capacity = 1;
            var spaceship = new Spaceship(name, capacity);

            var nameA = "NameA";
            var oxygen = 10.5;
            var astrounavt = new Astronaut(nameA, oxygen);
            spaceship.Add(astrounavt);


            Assert.Throws<InvalidOperationException>(() => spaceship.Add(new Astronaut("Test", 20)));
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationException_WhenAustronavtExists()
        {
            string name = "TestName";
            var capacity = 2;
            var spaceship = new Spaceship(name, capacity);

            var nameA = "NameA";
            var oxygen = 10.5;
            var astrounavt = new Astronaut(nameA, oxygen);
            spaceship.Add(astrounavt);


            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astrounavt));
        }

        [Test]
        public void Add_ShouldTAddCorrectly()
        {
            string name = "TestName";
            var capacity = 2;
            var spaceship = new Spaceship(name, capacity);

            var nameA = "NameA";
            var oxygen = 10.5;
            var astrounavt = new Astronaut(nameA, oxygen);
            spaceship.Add(astrounavt);


            Assert.That(spaceship.Count == 1);
        }

        [Test]
        public void Remove_ShouldRemoveCorrectly()
        {
            string name = "TestName";
            var capacity = 2;
            var spaceship = new Spaceship(name, capacity);

            var nameA = "NameA";
            var oxygen = 10.5;
            var astrounavt = new Astronaut(nameA, oxygen);
            spaceship.Add(astrounavt);

            spaceship.Remove(nameA);
            Assert.That(spaceship.Count == 0);
        }

        [Test]
        public void Remove_ShouldReturnTrue()
        {
            string name = "TestName";
            var capacity = 2;
            var spaceship = new Spaceship(name, capacity);

            var nameA = "NameA";
            var oxygen = 10.5;
            var astrounavt = new Astronaut(nameA, oxygen);
            spaceship.Add(astrounavt);

            Assert.That(spaceship.Remove(nameA) == true);
        }

        [Test]
        public void Remove_ShouldReturnFalse()
        {
            string name = "TestName";
            var capacity = 2;
            var spaceship = new Spaceship(name, capacity);

            var nameA = "NameA";
            var oxygen = 10.5;
            var astrounavt = new Astronaut(nameA, oxygen);
            spaceship.Add(astrounavt);

            Assert.That(spaceship.Remove("False") == false);
        }

    }
}