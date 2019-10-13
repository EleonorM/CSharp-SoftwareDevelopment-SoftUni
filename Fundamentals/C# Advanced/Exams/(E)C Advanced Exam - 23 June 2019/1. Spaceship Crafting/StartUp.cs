namespace _1._Spaceship_Crafting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var chemicals = new Dictionary<int, string>();
            chemicals.Add(25, "Glass");
            chemicals.Add(50, "Aluminium");
            chemicals.Add(75, "Lithium");
            chemicals.Add(100, "Carbon fiber");

            var chemicalsDone = new Dictionary<string, int>();
            chemicalsDone.Add("Glass", 0);
            chemicalsDone.Add("Aluminium", 0);
            chemicalsDone.Add("Lithium", 0);
            chemicalsDone.Add("Carbon fiber", 0);

            var liquids = new List<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());
            var physicalItems = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            while (liquids.Count > 0 && physicalItems.Count > 0)
            {
                var cuurentLiquid = liquids[0];
                var cuurentItem = physicalItems.Pop();

                if (chemicals.ContainsKey(cuurentItem + cuurentLiquid))
                {
                    chemicalsDone[chemicals[cuurentLiquid + cuurentItem]]++;
                }
                else
                {
                    physicalItems.Push(cuurentItem + 3);
                }

                liquids.RemoveAt(0);
            }

            var succseed = true;
            foreach (var kvp in chemicalsDone)
            {
                if (kvp.Value == 0)
                {
                    succseed = false;
                    break;
                }
            }

            if (succseed)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Count != 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
                Console.WriteLine("Liquids left: none");


            if (physicalItems.Count != 0)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", physicalItems)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            chemicalsDone = chemicalsDone.OrderBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in chemicalsDone)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
