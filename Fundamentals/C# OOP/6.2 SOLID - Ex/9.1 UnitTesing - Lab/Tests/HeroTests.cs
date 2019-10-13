using FluentAssertions;
using Moq;
using NUnit.Framework;


[TestFixture]
public class HeroTests
{

    private const string HeroName = "Pesho";
    [Test]
    public void Hero_GainsExperienceAfterAttackIfTargetDies()
    {
        var mockTarget = new Mock<ITarget>();
        mockTarget.Setup(p => p.Health).Returns(0);
        mockTarget.Setup(p => p.IsDead()).Returns(true);
        mockTarget.Setup(p => p.GiveExperience()).Returns(20);
        var mockWeapon = new Mock<IWeapon>();
        var hero = new Hero(HeroName, mockWeapon.Object);

        hero.Attack(mockTarget.Object);

        hero.Experience.Should().Be(20);

    }

}
