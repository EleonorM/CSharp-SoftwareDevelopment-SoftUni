using System;

namespace _08._Triangle_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int col = 1; col <= number; col++)
            {
                for (int i = 1; i <= col; i++)
                {
                    Console.Write(col+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
