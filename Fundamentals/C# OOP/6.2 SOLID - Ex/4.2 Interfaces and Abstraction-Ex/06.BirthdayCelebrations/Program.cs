namespace _06.BirthdayCelebrations
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

                if (input[0] == "Robot")
                {
                }
                else if (input[0] == "Citizen")
                {
                    var citizen = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
                    habitants.Add(citizen);
                }
                else if (input[0] == "Pet")
                {
                    var pet = new Pet(input[1], input[2]);
                    habitants.Add(pet);
                }
            }

            var fakeIdLastDigits = Console.ReadLine();
            foreach (var habitant in habitants)
            {
                string birthday = habitant.Birthday;
                if (string.Concat(birthday.Skip(birthday.Length - fakeIdLastDigits.Length).Take(fakeIdLastDigits.Length).ToArray()) == fakeIdLastDigits)
                {
                    Console.WriteLine(birthday);
                }
            }
        }
    }
}
