namespace _07._Predicate_For_Names
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var maxLenght = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Predicate<string> nameLenght = n => n.Length <= maxLenght;

            foreach (var name in input)
            {
                if (nameLenght(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
