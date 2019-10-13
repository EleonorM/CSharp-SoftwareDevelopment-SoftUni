namespace Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    [TestFixture]
    class AxeTests
    {
        [Test]
        public void Axe_LoosesDurabilityAfterAttack()
        {
            var attack = 10;
            var durability = 10;
            var health = 10;
            var expirience = 10;
            var axe = new Axe(attack, durability);
            var dummy = new Dummy(health, expirience);

            axe.Attack(dummy);

            var expected = 9;
            axe.DurabilityPoints.Should().Be(expected, "Axe durability doesn't change after attack.");
        }

        [Test]
        public void Axe_AttackingWithBrokenWeapon()
        {
            var attack = 10;
            var durability = 10;
            var health = 10;
            var expirience = 10;
            var axe = new Axe(attack, durability);
            var dummy = new Dummy(health, expirience);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}
