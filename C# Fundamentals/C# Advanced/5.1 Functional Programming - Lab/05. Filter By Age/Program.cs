namespace _05._Filter_By_Age
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            var people = new List<Person>();
            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine()
                .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);

                var person = new Person()
                {
                    Name = input[0],
                    Age = int.Parse(input[1])
                };

                people.Add(person);
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());

            Func<Person, bool> filter;
            if (condition == "older")
            {
                filter = p => p.Age >= age;
            }
            else
            {
                filter = p => p.Age < age;
            }

            var format = Console.ReadLine();

            Func<Person, string> selectFunc;

            if (format == "name age")
            {
                selectFunc = n => $"{n.Name} - {n.Age}";
            }
            else if (format == "name")
            {
                selectFunc = n => $"{n.Name}";
            }
            else
            {
                selectFunc = n => $"{n.Age}";
            }

            people.Where(filter).Select(selectFunc).ToList().ForEach(Console.WriteLine);
        }
    }
}
