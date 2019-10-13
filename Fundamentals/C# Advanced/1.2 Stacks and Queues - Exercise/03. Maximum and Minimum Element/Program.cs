namespace _03._Maximum_and_Minimum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var stack = new Stack<int>();
            var rows = int.Parse(Console.ReadLine());
            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (input.Length == 2)
                {
                    if (input[0] == 1)
                    {
                        stack.Push(input[1]);
                    }
                }
                else
                {
                    var action = input[0];
                    if (action == 2)
                    {
                        try
                        {
                            stack.Pop();
                        }
                        catch
                        {
                        }
                    }
                    else if (action == 3)
                    {
                        try
                        {
                            Console.WriteLine(stack.Max());
                        }
                        catch
                        {
                        } 
                    }
                    else if (action == 4)
                    {
                        try
                        {
                            Console.WriteLine(stack.Min());
                        }
                        catch
                        {
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
