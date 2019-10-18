namespace _06._Reversed_Chars
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            char input1 = char.Parse(Console.ReadLine());
            char input2 = char.Parse(Console.ReadLine());
            char input3 = char.Parse(Console.ReadLine());
            List<char> list = new List<char>();
            list.Add(input1);
            list.Add(input2);
            list.Add(input3);
            list.Reverse();
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
