namespace _02.MakeaSalad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var vegetablesArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var caloriesArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var vegetable = new Queue<string>(vegetablesArray);
            var calories = new Stack<int>(caloriesArray);
            var vegetableCalories = new Dictionary<string, int>
            {
                { "tomato", 80 },
                 { "carrot", 136 },
                 { "lettuce", 109 },
                 { "potato", 215 }
            };

            var readySalads = new List<int>();

            while (true)
            {
                if (calories.Count == 0)
                {
                    Console.WriteLine(string.Join(" ", readySalads));
                    Console.WriteLine(string.Join(" ", vegetable));
                    break;
                }

                if (vegetable.Count == 0)
                {
                    Console.WriteLine(string.Join(" ", readySalads));
                    Console.WriteLine(string.Join(" ", calories));
                    break;
                }

                var currentCalorie = calories.Peek();
                while (true)
                {
                    try
                    {
                        var currentVegetable = vegetable.Dequeue();
                        currentCalorie -= vegetableCalories[currentVegetable];
                        if (currentCalorie <= 0)
                        {
                            readySalads.Add(calories.Pop());
                            break;
                        }

                        if (vegetable.Count == 0)
                        {
                            readySalads.Add(calories.Pop());
                            break;
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
            }
        }
    }
}
