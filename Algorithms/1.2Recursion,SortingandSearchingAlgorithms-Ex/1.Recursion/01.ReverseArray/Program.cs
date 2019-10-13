namespace _01.ReverseArray
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Reverse(numbers,0);
        }

        private static void Reverse(int[] numbers, int index)
        {
            if (index == numbers.Length)
            {
                return;
            }

            Reverse(numbers, index + 1);
            Console.Write(numbers[index]+" ");
        }
    }
}
