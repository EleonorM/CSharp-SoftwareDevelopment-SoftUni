namespace _05._Print_Part_Of_ASCII_Table
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                Console.Write((char)i + " ");
            }

            Console.WriteLine();
        }
    }
}
