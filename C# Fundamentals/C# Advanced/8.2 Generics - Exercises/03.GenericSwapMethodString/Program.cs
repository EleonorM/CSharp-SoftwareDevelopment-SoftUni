namespace _03.GenericSwapMethodString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var inputLines = int.Parse(Console.ReadLine());
            var ListOfBox = new List<Box<string>>();
            for (int i = 0; i < inputLines; i++)
            {
                var input = Console.ReadLine();
                var box = new Box<string>(input);
                ListOfBox.Add(box);
            }

            var indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var index1 = indexes[0];
            var index2 = indexes[1];
            ListOfBox = ListOfBox.Swap(index1, index2);

            foreach (var item in ListOfBox)
            {
                Console.WriteLine(item);
            }
        }
    }
}
