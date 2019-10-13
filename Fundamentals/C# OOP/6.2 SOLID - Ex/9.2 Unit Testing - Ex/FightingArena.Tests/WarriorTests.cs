using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_SetValidProperty()
        {
            var name = "TestName";
            var damage = 10;
            var hp = 10;
            var warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_IfNameIsNullOrWhiteSpace()
        {
            string name = null;
            var damage = 10;
            var hp = 10;

            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_IfDamageIsBelowOrEqualTo0()
        {
            var name = "TestName";
            var damage = 0;
            var hp = 10;

            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_IfHpIsBelowOrEqualTo0()
        {
            var name = "TestName";
            var damage = 10;
            var hp = -1;

            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void Attack_ShouldThrowArgumentException_IfAttackerHpIsBelowMinAttackHp()
        {
            var name1 = "TestName1";
            var damage1 = 10;
            var hp1 = 10;
            var name2 = "TestName2";
            var damage2 = 5;
            var hp2 = 40;
            var warrior1 = new Warrior(name1, damage1, hp1);
            var warrior2 = new Warrior(name2, damage2, hp2);

            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void Attack_ShouldThrowArgumentException_IfAttackedHpIsBelowMinAttackHp()
        {
            var name1 = "TestName1";
            var damage1 = 30;
            var hp1 = 40;
            var name2 = "TestName2";
            var damage2 = 10;
            var hp2 = 10;
            var warrior1 = new Warrior(name1, damage1, hp1);
            var warrior2 = new Warrior(name2, damage2, hp2);

            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void Attack_ShouldThrowArgumentException_IfAttackerHpIsBelowAttackedDamage()
        {
            var name1 = "TestName1";
            var damage1 = 10;
            var hp1 = 40;
            var name2 = "TestName2";
            var damage2 = 50;
            var hp2 = 50;
            var warrior1 = new Warrior(name1, damage1, hp1);
            var warrior2 = new Warrior(name2, damage2, hp2);

            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void Attack_ShouldDecraseAttackerWarriorHp()
        {
            var name1 = "TestName1";
            var damage1 = 10;
            var hp1 = 40;
            var name2 = "TestName2";
            var damage2 = 30;
            var hp2 = 40;
            var warrior1 = new Warrior(name1, damage1, hp1);
            var warrior2 = new Warrior(name2, damage2, hp2);

            warrior1.Attack(warrior2);
            var expected = 10;
            var actual = warrior1.HP;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Attack_ShouldDecraseAttackedWarriorHpTo0IfAttackerDamageIsBigger()
        {
            var name1 = "TestName1";
            var damage1 = 50;
            var hp1 = 40;
            var name2 = "TestName2";
            var damage2 = 30;
            var hp2 = 40;
            var warrior1 = new Warrior(name1, damage1, hp1);
            var warrior2 = new Warrior(name2, damage2, hp2);

            warrior1.Attack(warrior2);
            var expected = 0;
            var actual = warrior2.HP;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Attack_ShouldDecraseAttackedWarriorHpIfAttackerDamageIsSmallerOrEqual()
        {
            var name1 = "TestName1";
            var damage1 = 50;
            var hp1 = 40;
            var name2 = "TestName2";
            var damage2 = 30;
            var hp2 = 60;
            var warrior1 = new Warrior(name1, damage1, hp1);
            var warrior2 = new Warrior(name2, damage2, hp2);

            warrior1.Attack(warrior2);
            var expected = 10;
            var actual = warrior2.HP;
            
            Assert.AreEqual(expected, actual);
        }
    }
}