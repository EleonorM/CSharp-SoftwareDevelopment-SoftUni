namespace _01.GenericBoxofString
{
    using System;
    using System.Collections.Generic;

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

            foreach (var item in ListOfBox)
            {
                Console.WriteLine(item);
            }
        }
    }
}
