using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_InitializeWarriors()
        {
            var arena = new Arena();

            var expected = 0;
            var actual = arena.Warriors.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Count_ReturnsValidAmount()
        {
            var name1 = "TestName1";
            var damage1 = 10;
            var hp1 = 40;
            var warrior = new Warrior(name1, damage1, hp1);
            var arena = new Arena();

            arena.Enroll(warrior);

            var expected = 1;
            var actual = arena.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Enroll_AddsWarrior()
        {
            var name1 = "TestName1";
            var damage1 = 10;
            var hp1 = 40;
            var warrior = new Warrior(name1, damage1, hp1);
            var arena = new Arena();

            arena.Enroll(warrior);

            var expected = 1;
            var actual = arena.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Enroll_ShouldThrowInvalidOperationException_WhenWarriorWithSameNameAlreadyExist()
        {
            var name1 = "TestName1";
            var damage1 = 10;
            var hp1 = 40;
            var warrior = new Warrior(name1, damage1, hp1);
            var name2 = "TestName1";
            var damage2 = 20;
            var hp2 = 50;
            var warrior2 = new Warrior(name2, damage2, hp2);

            var arena = new Arena();

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior2));
        }

        [Test]
        public void Fight_ShouldThrowInvalidOperationException_WhenWarriorDoesNotExist()
        {
            var name1 = "TestName1";
            var damage1 = 10;
            var hp1 = 40;
            var warrior = new Warrior(name1, damage1, hp1);
            var name2 = "TestName2";
            var damage2 = 20;
            var hp2 = 50;
            var warrior2 = new Warrior(name2, damage2, hp2);

            var arena = new Arena();
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(name1, name2));
        }

        [Test]
        public void Fight_AttackerShoulAttackEnemy()
        {
            var name1 = "TestName1";
            var damage1 = 10;
            var hp1 = 40;
            var warrior = new Warrior(name1, damage1, hp1);
            var name2 = "TestName2";
            var damage2 = 30;
            var hp2 = 40;
            var warrior2 = new Warrior(name2, damage2, hp2);

            var arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(warrior2);

            arena.Fight(name1, name2);

            Assert.AreEqual(10, warrior.HP);
            Assert.AreEqual(30, warrior2.HP);
        }
    }
}
