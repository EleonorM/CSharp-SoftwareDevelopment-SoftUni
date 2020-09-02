namespace _4.VariationsWithRepetition
{
    using System;

    public class Program
    {
        private static char[] elements;
        private static char[] variations;
        public static void Main()
        {
            elements = Console.ReadLine().Replace(" ", string.Empty).ToCharArray();
            var positions = int.Parse(Console.ReadLine());
            variations = new char[positions];
            Gen(0);
        }

        public static void Gen(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    variations[index] = elements[i];
                    Gen(index + 1);
                }
            }
        }

    }
}