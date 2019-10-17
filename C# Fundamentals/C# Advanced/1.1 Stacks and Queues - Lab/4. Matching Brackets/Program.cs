namespace _4._Matching_Brackets
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            Stack<int> sybmols = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    sybmols.Push(i);
                }
                else if (input[i] == ')')
                {
                    int openBracketIndex = sybmols.Pop();
                    Console.WriteLine(input.Substring(openBracketIndex, i - openBracketIndex + 1));
                }
            }
        }
    }
}
