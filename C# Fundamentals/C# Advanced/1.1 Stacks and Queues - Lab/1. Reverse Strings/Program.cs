namespace _1._Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            Stack<char> result = new Stack<char>();
            var input = Console.ReadLine();

            foreach (var symbol in input)
            {
                result.Push(symbol);
            }

            while (result.Count != 0)
            {
                Console.Write(result.Pop());
            }

            Console.WriteLine();
        }
    }
}
