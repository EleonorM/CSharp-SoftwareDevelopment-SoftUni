namespace _02.GenericBoxofInteger
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var inputLines = int.Parse(Console.ReadLine());
            var ListOfBox = new List<Box<int>>();
            for (int i = 0; i < inputLines; i++)
            {
                var input = int.Parse(Console.ReadLine());
                var box = new Box<int>(input);
                ListOfBox.Add(box);
            }

            foreach (var item in ListOfBox)
            {
                Console.WriteLine(item);
            }
        }
    }
}
