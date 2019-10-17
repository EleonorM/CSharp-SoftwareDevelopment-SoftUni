namespace _01._Club_Party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var capacity = int.Parse(Console.ReadLine());
            var halls = new Queue<char>();
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var actions = new Stack<string>(input);
            var currentCapacity = capacity;
            var currentPeople = new List<int>();
            while (true)
            {
                if (actions.Count == 0)
                {
                    break;
                }

                var currentAction = actions.Pop();
                var isNumber = int.TryParse(currentAction, out int number);

                if (isNumber)
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    if (currentCapacity - number < 0)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", currentPeople)}");
                        currentPeople.Clear();
                        currentCapacity = capacity;
                    }

                    if (halls.Count > 0)
                    {
                        currentPeople.Add(number);
                        currentCapacity -= number;
                    }
                }
                else
                {
                    halls.Enqueue(char.Parse(currentAction));
                }
            }
        }
    }
}
