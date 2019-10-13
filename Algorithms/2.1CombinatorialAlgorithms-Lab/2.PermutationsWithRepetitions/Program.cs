namespace _2.PermutationsWithRepetitions
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Permute(char[] elements, int start, int end)
        {
            Print(elements);
            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (elements[left] != elements[right])
                    {
                        Swap(ref elements[left], ref elements[right]);
                        Permute(elements, left + 1, end);
                    }
                }

                var firstElement = elements[left];
                for (int i = left; i <= end - 1; i++)
                {
                    elements[i] = elements[i + 1];
                }
                elements[end] = firstElement;
            }
        }

        private static void Print(char[] elements)
        {
            Console.WriteLine(string.Join(" ", elements));
        }

        private static void Swap(ref char first, ref char second)
        {
            var temp = first;
            first = second;
            second = temp;
        }

        public static void Main()
        {
            var elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            Array.Sort(elements);
            Permute(elements, 0, elements.Length - 1);
        }
    }
}
