namespace _10._Poke_Mon
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int nOriginal = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            byte y = byte.Parse(Console.ReadLine());
            int n = nOriginal;
            int pokeCounter = 0;

            while (true)
            {
                if (n * 2 == nOriginal && y != 0)
                {
                    n = n / y;
                }
                if (n < m)
                {
                    break;
                }
                else
                {
                    n -= m;
                }

                pokeCounter++;
            }

            Console.WriteLine(n);
            Console.WriteLine(pokeCounter);
        }
    }
}
