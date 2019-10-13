namespace _01.ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            try
            {
                var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var numbersInStack = new Stack<int>(numbers);

                Console.WriteLine(string.Join(" ", numbersInStack));
            }
            catch 
            {
            }
        }
    }
}
