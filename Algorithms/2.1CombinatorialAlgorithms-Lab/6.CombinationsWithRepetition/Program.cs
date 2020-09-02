namespace _6.CombinationsWithRepetition
{
using System;

    public class Program
    {
        private static char[] elements;
        private static char[] variations;

        public static void Main()
        {
            elements = Console.ReadLine().Replace(" ", string.Empty).ToCharArray(); ;
            var positions = int.Parse(Console.ReadLine());
            variations = new char[positions];
            GenerateCombinations(elements.Length, 0);
        }

        public static void GenerateCombinations(int sizeOfSet, int index, int start = 0)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
            }
            else
            {
                for (int i = start; i < sizeOfSet; i++)
                {
                    variations[index] = elements[i];
                    GenerateCombinations(sizeOfSet, index + 1, i );
                }
            }
        }
    }
}
