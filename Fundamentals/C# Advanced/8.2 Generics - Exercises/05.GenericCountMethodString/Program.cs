namespace _05.GenericCountMethodString
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            var inputLines = int.Parse(Console.ReadLine());
            var ListOfBox = new List<Box<string>>();
            for (int i = 0; i < inputLines; i++)
            {
                var input = Console.ReadLine();
                var box = new Box<string>(input);
                ListOfBox.Add(box);
            }

            var elementToComapre = Console.ReadLine();
            var element = new Box<string>(elementToComapre);
            var count = ListOfBox.Compare(element);

            Console.WriteLine(count);
        }
    }
}
