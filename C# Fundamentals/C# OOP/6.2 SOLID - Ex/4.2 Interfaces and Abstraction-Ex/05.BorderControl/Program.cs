namespace _05.BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var habitants = new List<Habitant>();

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }

                if (input.Length == 2)
                {
                    var robot = new Robot(input[0], input[1]);
                    habitants.Add(robot);
                }
                else if (input.Length == 3)
                {
                    var citizen = new Citizen(input[0], int.Parse(input[1]), input[2]);
                    habitants.Add(citizen);
                }
            }

            var fakeIdLastDigits = Console.ReadLine();
            foreach (var habitant in habitants)
            {
                string id = habitant.Id;
                if (string.Concat(id.Skip(id.Length - fakeIdLastDigits.Length).Take(fakeIdLastDigits.Length).ToArray()) == fakeIdLastDigits)
                {
                    Console.WriteLine(id);
                }
            }
        }
    }
}
