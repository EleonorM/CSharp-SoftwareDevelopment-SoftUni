namespace _06.Challenge_the_Wedding
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int maleCounte = int.Parse(Console.ReadLine());
            int femaleCounte = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());
            var counter = 0;
            for (int i = 1; i <= maleCounte; i++)
            {
                for (int j = 1; j <= femaleCounte; j++)
                {
                    if (counter < tables)
                    {
                        Console.Write($"({i} <-> {j}) ");
                        counter++;
                    }
                }
            }
        }
    }
}
