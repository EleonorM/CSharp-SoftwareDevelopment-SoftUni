namespace _03._CharactersInRange
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var startChar = char.Parse(Console.ReadLine());
            var endChar = char.Parse(Console.ReadLine());
            PrintInRange(startChar, endChar);
        }

        static void PrintInRange(char start, char end)
        {
            if (start > end)
            {
                for (int i = end + 1; i < start; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
            else
            {
                for (int i = start + 1; i < end; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
        }
    }
}
