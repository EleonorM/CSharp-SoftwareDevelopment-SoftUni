namespace _1._Rhombus_of_Stars
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                PrintLine(1, i, num);
            }
            for (int i = num - 1; i > 0; i--)
            {
                PrintLine(1, i, num);
            }

        }
        static void PrintLine(int start, int end, int maxNum)
        {
            Console.Write(new string(' ', maxNum-end));
            for (int i = start; i <= end; i++)
            {
                Console.Write("*" + " ");
            }
            Console.WriteLine();
        }
    }
}
