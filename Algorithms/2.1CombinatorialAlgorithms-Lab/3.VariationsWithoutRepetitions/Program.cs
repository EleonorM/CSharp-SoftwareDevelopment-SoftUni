namespace _3.VariationsWithoutRepetitions
{
    using System;
    using System.Linq;

    public class Program
    {
        private static char[] elements;
        private static char[] variations;
        private static bool[] used;

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
                    if (!used[i])
                    {
                        used[i] = true;
                        variations[index] = elements[i];
                        Gen(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        public static void Main()
        {
            elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
           var positions = int.Parse(Console.ReadLine());
            variations = new char[positions];
            used = new bool[elements.Length];
            Gen(0);
        }
    }
}
