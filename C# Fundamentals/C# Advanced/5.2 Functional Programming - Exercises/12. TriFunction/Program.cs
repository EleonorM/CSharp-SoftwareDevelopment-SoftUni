namespace _12._TriFunction
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isLarger = (str, n) => str.Sum(a => a) >= number;
            Func<string[], Func<string, int, bool>, string> nameFilter = (inputNames, isLargerFilter) =>
              inputNames
              .FirstOrDefault(x => isLargerFilter(x, number));
            var resutlName = nameFilter(names, isLarger);
            Console.WriteLine(resutlName);
        }
    }
}
