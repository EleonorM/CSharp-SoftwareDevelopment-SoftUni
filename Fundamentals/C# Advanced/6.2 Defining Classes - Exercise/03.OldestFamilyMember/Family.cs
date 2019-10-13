namespace DefiningClasses
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        public List<Person> People;

        public Family()
        {
            this.People = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.People.OrderByDescending(p => p.Age).First();
        }
    }
}
