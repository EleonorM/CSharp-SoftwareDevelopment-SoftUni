namespace _04._ReverseArrayOfStrings
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string[] array = Console.ReadLine().Split().ToArray();
            for (int i = 0; i < array.Length / 2; i++)
            {
                ArrayReverse(array, i, array.Length - 1 - i);
            }
            Console.WriteLine(string.Join(" ", array));

        }
        static void ArrayReverse(string[] arr, int i, int j)
        {
            var newArray = arr[i];
            arr[i] = arr[j];
            arr[j] = newArray;
        }
    }
}
