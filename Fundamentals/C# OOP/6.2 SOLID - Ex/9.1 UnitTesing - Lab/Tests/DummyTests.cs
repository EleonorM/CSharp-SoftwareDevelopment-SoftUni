namespace Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Dummy_LoosesHealt_IfAttacked()
        {
            var health = 10;
            var expirience = 10;
            var dummy = new Dummy(health, expirience);

            dummy.TakeAttack(2);

            dummy.Health.Should().Be(8);
        }

        [Test]
        public void Dummy_ThrowsException_IfDead()
        {
            var health = 0;
            var expirience = 10;
            var dummy = new Dummy(health, expirience);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(2));
        }

        [Test]
        public void Dummy_GiveHpWhenDead()
        {
            var health = 0;
            var expirience = 10;
            var dummy = new Dummy(health, expirience);

            dummy.GiveExperience().Should().Be(10);
        }

        [Test]
        public void Dummy_DoesNotGiveHpWhenAlive()
        {
            var health = 10;
            var expirience = 10;
            var dummy = new Dummy(health, expirience);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
