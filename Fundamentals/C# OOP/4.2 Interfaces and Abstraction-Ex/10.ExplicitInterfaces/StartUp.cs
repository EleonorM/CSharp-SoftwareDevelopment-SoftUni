namespace _10.ExplicitInterfaces
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var residents = new List<IResident>();
            var people = new List<IPerson>();

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }

                var citizen = new Citizen(input[0], input[1], int.Parse(input[2]));
                residents.Add(citizen);
                people.Add(citizen);
            }

            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine(people[i].GetName());
                Console.WriteLine(residents[i].GetName());
            }
        }
    }
}
