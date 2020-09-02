namespace _2.PermutationsWithRepetitions
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static char[] elements;

        public static void Main()
        {
            elements = Console.ReadLine().Replace(" ", string.Empty).ToCharArray();
            Permute(elements, 0);
        }

        public static void Permute(char[] elements, int index)
        {
            if (index >= elements.Length)
            {
                Print(elements);
            }
            else
            {
                var swapped = new HashSet<char>();
                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        Permute(elements, index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);
                    }
                }
            }
        }

        private static void Print(char[] elements)
        {
            Console.WriteLine(string.Join(" ", elements));
        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
