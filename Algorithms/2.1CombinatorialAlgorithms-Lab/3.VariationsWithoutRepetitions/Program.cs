namespace _3.VariationsWithoutRepetitions
{
    using System;

    public class Program
    {
        private static char[] elements;
        private static char[] variations;
        private static bool[] used;

        public static void Main()
        {
            elements = Console.ReadLine().Replace(" ", string.Empty).ToCharArray(); ;
            var positions = int.Parse(Console.ReadLine());
            variations = new char[positions];
            used = new bool[elements.Length];
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

    }
}
