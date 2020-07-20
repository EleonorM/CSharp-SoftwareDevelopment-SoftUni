using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> peopleByEmail = new Dictionary<string, Person>();
    private Dictionary<string, SortedSet<Person>> peopleByEmailDomain = new Dictionary<string, SortedSet<Person>>();
    private Dictionary<string, SortedSet<Person>> peopleByNameAndTown = new Dictionary<string, SortedSet<Person>>();
    private OrderedDictionary<int, SortedSet<Person>> peopleByAge = new OrderedDictionary<int, SortedSet<Person>>();
    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> peopleByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

    // private List<Person> people = new List<Person>();

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

        peopleByEmail.Add(email, person);

        var emailDomain = this.ExtractEmailDomain(email);
        peopleByEmailDomain.AppendValueToKey(emailDomain, person);

        var nameAndTown = this.CombineNameAndTown(name, town);
        peopleByNameAndTown.AppendValueToKey(nameAndTown, person);

        peopleByAge.AppendValueToKey(age, person);

        peopleByTownAndAge.EnsureKeyExists(town);
        peopleByTownAndAge[town].AppendValueToKey(age, person);
        return true;
    }

    public int Count
    {
        get
        {
            return peopleByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        Person person;
        var personExists = peopleByEmail.TryGetValue(email, out person);
        return person;
    }

    public bool DeletePerson(string email)
    {
        var personToDelete = FindPerson(email);
        if (personToDelete == null)
        {
            return false;
        }

        peopleByEmail.Remove(email);

        var emailDomain = this.ExtractEmailDomain(email);
        peopleByEmailDomain[emailDomain].Remove(personToDelete);

        var nameAndTown = this.CombineNameAndTown(personToDelete.Name, personToDelete.Town);
        peopleByNameAndTown[nameAndTown].Remove(personToDelete);

        peopleByAge[personToDelete.Age].Remove(personToDelete);

        peopleByTownAndAge[personToDelete.Town][personToDelete.Age].Remove(personToDelete);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        return peopleByEmailDomain.GetValuesForKey(emailDomain);
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var nameAndTown = this.CombineNameAndTown(name, town);
        return this.peopleByNameAndTown.GetValuesForKey(nameAndTown);
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var peopleInRange = peopleByAge.Range(startAge, true, endAge, true);

        foreach (var people in peopleInRange)
        {
            foreach (var person in people.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.peopleByTownAndAge.ContainsKey(town))
        {
            yield break;
        }

        var peopleInRange = this.peopleByTownAndAge[town].Range(startAge, true, endAge, true);

        foreach (var people in peopleInRange)
        {
            foreach (var person in people.Value)
            {
                yield return person;
            }
        }
    }

    private string ExtractEmailDomain(string email)
    {
        var domain = email.Split('@')[1];
        return domain;
    }

    private string CombineNameAndTown(string name, string town)
    {
        const string separator = "|!|";
        return name + separator + town;
    }
}
