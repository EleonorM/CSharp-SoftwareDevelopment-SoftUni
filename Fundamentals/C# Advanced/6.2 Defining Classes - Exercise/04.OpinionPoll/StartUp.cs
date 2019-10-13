namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        public static void Main()
        {
            var numberOfPeople = int.Parse(Console.ReadLine());
            var olderThan30 = new List<Person>();
            for (int i = 0; i < numberOfPeople; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);
                var person = new Person(name, age);
                if (person.Age >30)
                {
                    olderThan30.Add(person);
                }
            }

            olderThan30 = olderThan30.OrderBy(n => n.Name).ToList();
            foreach (var person in olderThan30)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
