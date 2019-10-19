namespace _05._DecryptingMessage
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int key = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());
            List<char> result = new List<char>();
            for (int i = 0; i < lines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                int temp = letter;
                temp += key;
                result.Add(Convert.ToChar(temp));
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}
