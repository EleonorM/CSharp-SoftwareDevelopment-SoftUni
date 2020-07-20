using System.Collections.Generic;
using System.Linq;

public class PersonCollectionSlow : IPersonCollection
{
    private List<Person> people = new List<Person>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (FindPerson(email) != null)
        {
            return false;
        }

        var person = new Person()
        {
            Email = email,
            Age = age,
            Name = name,
            Town = town,
        };
        people.Add(person);
        return true;
    }

    public int Count
    {
        get
        {
            return people.Count;
        }
    }

    public Person FindPerson(string email)
    {
        return people.FirstOrDefault(x => x.Email == email);
    }

    public bool DeletePerson(string email)
    {
        var personToDelete = FindPerson(email);
        if (personToDelete == null)
        {
            return false;
        }
        people.Remove(personToDelete);
        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        return people
            .Where(x => x.Email.EndsWith("@" + emailDomain))
            .OrderBy(x => x.Email);
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        return people
            .Where(x => x.Name == name && x.Town == town)
            .OrderBy(x => x.Email);
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        return people
            .Where(x => x.Age >= startAge && x.Age <= endAge)
            .OrderBy(x => x.Age)
            .ThenBy(x => x.Email);
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        return people
            .Where(x => x.Town == town)
            .Where(x => x.Age >= startAge && x.Age <= endAge)
            .OrderBy(x => x.Age)
            .ThenBy(x => x.Email);
    }
}
