namespace _05._Applied_Arithmetics
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Func<int, int> increaseByOne = n => n = n + 1;
            Func<int, int> multiply = n => n = n * 2;
            Func<int, int> subtract = n => n = n - 1;
            Action<int[]> print = a => Console.WriteLine(string.Join(" ", a));

            while (true)
            {
                var action = Console.ReadLine().ToLower();
                if (action == "end")
                {
                    break;
                }

                if (action == "add")
                {
                    input = input.Select(increaseByOne).ToArray();
                }
                else if (action == "multiply")
                {
                    input = input.Select(multiply).ToArray();
                }
                else if (action == "subtract")
                {
                    input = input.Select(subtract).ToArray();
                }
                else if (action == "print")
                {
                    print(input);
                }
            }
        }
    }
}
