namespace _01._Train
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            var maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                var inputString = input.Split();
                if (inputString[0] == "Add")
                {
                    wagons.Add(int.Parse(inputString[1]));
                }
                else
                {
                    var num = int.Parse(inputString[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + num <= maxCapacity)
                        {
                            wagons[i] += num;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
