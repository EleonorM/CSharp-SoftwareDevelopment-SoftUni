namespace _07._Order_by_Age
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var people = new List<Person>();
            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }
                var person = new Person();
                person.Name = input[0];
                person.ID = input[1];
                person.Age = int.Parse(input[2]);
                people.Add(person);
            }

            people = people.OrderBy(o => o.Age).ToList();
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }

    class Person
    {
        public string Name;
        public string ID;
        public int Age;
    }
}
