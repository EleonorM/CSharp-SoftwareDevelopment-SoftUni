namespace _08._Balanced_Parenthesis
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();
            var stack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                if (currentChar == '{' || currentChar == '[' || currentChar == '(')
                {
                    stack.Push(currentChar);
                }
                else
                {
                    try
                    {
                        var charToCompare = stack.Pop();
                        if ((charToCompare == '[' && currentChar == ']')
                        || (charToCompare == '{' && currentChar == '}')
                        || (charToCompare == '(' && currentChar == ')'))
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
