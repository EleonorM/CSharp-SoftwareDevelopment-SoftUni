namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var numberOfPeople = int.Parse(Console.ReadLine());
            var family = new Family();
            for (int i = 0; i < numberOfPeople; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);
                var person = new Person(name, age);
                family.AddMember(person);
            }

            var oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
