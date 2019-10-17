namespace _3._Simple_Calculator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            Stack<string> sybmols = new Stack<string>(input.Reverse());

            var result = int.Parse(sybmols.Pop());

            while (sybmols.Any())
            {
                var nextSybmol = sybmols.Pop();
                if (nextSybmol == "+")
                {
                    int nextNumber = int.Parse(sybmols.Pop());
                    result += nextNumber;
                }
                else if (nextSybmol == "-")
                {
                    int nextNumber = int.Parse(sybmols.Pop());
                    result -= nextNumber;
                }
            }

            Console.WriteLine(result);
        }
    }
}
