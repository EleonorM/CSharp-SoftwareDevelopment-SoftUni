namespace _06.GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var inputLines = int.Parse(Console.ReadLine());
            var ListOfBox = new List<Box<double>>();
            for (int i = 0; i < inputLines; i++)
            {
                var input = double.Parse(Console.ReadLine());
                var box = new Box<double>(input);
                ListOfBox.Add(box);
            }

            var elementToComapre = double.Parse(Console.ReadLine());
            var element = new Box<double>(elementToComapre);
            var count = ListOfBox.Compare(element);

            Console.WriteLine(count);
        }
    }
}
