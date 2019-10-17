namespace _02._Oldest_Family_Member
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var members = int.Parse(Console.ReadLine());
            var family = new Family();
            for (int i = 0; i < members; i++)
            {
                var person = new Person();
                var input = Console.ReadLine().Split();
                person.Name = input[0];
                person.Age = int.Parse(input[1]);
                family.AddMember(person);
            }

            var oldestMember = family.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }

    class Person
    {
        public string Name;
        public int Age;
    }

    class Family
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
