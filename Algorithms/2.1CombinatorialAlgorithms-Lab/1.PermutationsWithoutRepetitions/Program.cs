namespace _1.PermutationsWithoutRepetitions
{
    using System;

    public class Program
    {
        private static char[] elements;

        public static void Main()
        {
            elements = Console.ReadLine().Replace(" ", string.Empty).ToCharArray();
            Permute(0);
        }

        public static void Permute(int index)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                Permute(index + 1);
                for (int i = index + 1; i < elements.Length; i++)
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                }
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
