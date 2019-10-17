namespace _01._Count_Chars_in_a_String
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var characters = new Dictionary<char, int>();
            var input = Console.ReadLine().ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    continue;
                }
                if (!characters.ContainsKey(input[i]))
                {
                    characters[input[i]] = 1;
                }
                else
                {
                    characters[input[i]]++;
                }
            }

            foreach (var kvp in characters)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
