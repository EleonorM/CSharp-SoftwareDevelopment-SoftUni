namespace _07.FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var habitants = new List<Habitant>();
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split();
                if (input.Length == 4)
                {
                    var citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    habitants.Add(citizen);
                }
                else if (input.Length == 3)
                {
                    var rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    habitants.Add(rebel);
                }
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                if (habitants.FirstOrDefault(x => x.Name == input) != null)
                {
                    habitants.FirstOrDefault(x => x.Name == input).BuyFood();
                }
            }

            Console.WriteLine(habitants.Sum(x=>x.Food));
        }
    }
}
