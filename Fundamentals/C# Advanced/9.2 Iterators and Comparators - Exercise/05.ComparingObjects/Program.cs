namespace _05.ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var people = new List<Person>();
            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "END")
                {
                    break;
                }

                var person = new Person(input[0], int.Parse(input[1]), input[2]);
                people.Add(person);
            }

            var n = int.Parse(Console.ReadLine());
            var countOfMatches = 0;
            var countOfNotEqual = 0;

            var targetPerson = people[n - 1];

            foreach (var person in people)
            {
                if (person.CompareTo(targetPerson) == 0)
                {
                    countOfMatches++;
                }
                else
                {
                    countOfNotEqual++;
                }
            }

            if (countOfMatches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
                Console.WriteLine($"{countOfMatches} {countOfNotEqual} {people.Count}");
        }
    }
}
