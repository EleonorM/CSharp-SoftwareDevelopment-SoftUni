namespace _09._Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var stackOfText = new Stack<string>();
            var text = string.Empty;
            var commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = input[0];
                if (command == "1")
                {
                    stackOfText.Push(text);
                    text += input[1];
                }
                else if (command == "2")
                {
                    stackOfText.Push(text);
                    var lenght = int.Parse(input[1]);
                    text = text.Substring(0,text.Length - lenght);
                }
                else if (command == "3")
                {
                    var index = int.Parse(input[1]);
                    Console.WriteLine(text[index - 1]);

                }
                else if (command == "4")
                {
                    text = stackOfText.Pop();
                }
            }
        }
    }
}
