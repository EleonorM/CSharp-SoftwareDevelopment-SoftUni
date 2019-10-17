namespace _08._Custom_Comparator
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int, int, int> softFunc = (x, y)
                => (x % 2 == 0 && y % 2 != 0) ? -1
                : (x % 2 != 0 && y % 2 == 0) ? 1
                : x > y ? 1
                : x < y ? -1
                : 0;

            Array.Sort(input, (x, y) => softFunc(x, y));
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
