namespace _01.ReverseArray
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numsInOrder = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Reverse(ref numsInOrder, 0);
            Console.WriteLine(string.Join(" ", numsInOrder));
        }

        public static void Reverse(ref int[] arr, int index)
        {
            if (index == arr.Length / 2)
            {
                return;
            }

            var tempNum = arr[index];
            arr[index] = arr[arr.Length - 1 - index];
            arr[arr.Length - 1 - index] = tempNum;
            Reverse(ref arr, index + 1);
        }
    }
}
