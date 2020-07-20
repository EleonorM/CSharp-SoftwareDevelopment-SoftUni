using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

[TestClass]
public class PerformanceTestsPersonCollection
{
    private IPersonCollection people;

    [TestInitialize]
    public void TestInitialize()
    {
        // this.people = new PersonCollectionSlow();
        this.people = new PersonCollection();
    }

    private void AddPersons(int count)
    {
        for (int i = 0; i < count; i++)
        {
            this.people.AddPerson(
                email: "pesho" + i + "@gmail" + (i % 100) + ".com",
                name: "Pesho" + (i % 100),
                age: i % 100,
                town: "Sofia" + (i % 100));
        }
    }

    [TestMethod]
    [Timeout(250)]
    public void TestPerformance_AddPerson()
    {
        // Act
        AddPersons(5000);
        Assert.AreEqual(5000, this.people.Count);
    }

    [TestMethod]
    [Timeout(200)]
    public void TestPerformance_FindPerson()
    {
        // Arrange
        AddPersons(5000);

        // Act
        for (int i = 0; i < 100000; i++)
        {
            var existingPerson = this.people.FindPerson("pesho1@gmail1.com");
            Assert.IsNotNull(existingPerson);
            var nonExistingPerson = this.people.FindPerson("non-existing email");
            Assert.IsNull(nonExistingPerson);
        }
    }

    [TestMethod]
    [Timeout(300)]
    public void TestPerformance_FindPersonsByEmailDomain()
    {
        // Arrange
        AddPersons(5000);

        // Act
        for (int i = 0; i < 10000; i++)
        {
            var existingPersons =
                this.people.FindPersons("gmail1.com").ToList();
            Assert.AreEqual(50, existingPersons.Count);
            var notExistingPersons =
                this.people.FindPersons("non-existing email").ToList();
            Assert.AreEqual(0, notExistingPersons.Count);
        }
    }

    [TestMethod]
    [Timeout(300)]
    public void TestPerformance_FindPersonsByNameAndTown()
    {
        // Arrange
        AddPersons(5000);

        // Act
        for (int i = 0; i < 10000; i++)
        {
            var existingPersons =
                this.people.FindPersons("Pesho1", "Sofia1").ToList();
            Assert.AreEqual(50, existingPersons.Count);
            var notExistingPersons =
                this.people.FindPersons("Pesho1", "Sofia5").ToList();
            Assert.AreEqual(0, notExistingPersons.Count);
        }
    }

    [TestMethod]
    [Timeout(300)]
    public void TestPerformance_FindPersonsByAgeRange()
    {
        // Arrange
        AddPersons(5000);

        // Act
        for (int i = 0; i < 2000; i++)
        {
            var existingPersons =
                this.people.FindPersons(20, 21).ToList();
            Assert.AreEqual(100, existingPersons.Count);
            var notExistingPersons =
                this.people.FindPersons(500, 600).ToList();
            Assert.AreEqual(0, notExistingPersons.Count);
        }
    }

    [TestMethod]
    [Timeout(300)]
    public void TestPerformance_FindPersonsByTownAndAgeRange()
    {
        // Arrange
        AddPersons(5000);

        // Act
        for (int i = 0; i < 5000; i++)
        {
            var existingPersons =
                this.people.FindPersons(18, 22, "Sofia20").ToList();
            Assert.AreEqual(50, existingPersons.Count);
            var notExistingTownPersons =
                this.people.FindPersons(20, 30, "Missing town").ToList();
            Assert.AreEqual(0, notExistingTownPersons.Count);
            var notExistingAgePersons =
                this.people.FindPersons(200, 300, "Sofia1").ToList();
            Assert.AreEqual(0, notExistingTownPersons.Count);
        }
    }
}
