namespace _4.Generating_0_1_Vectors
{
    using System;

    public class Program
    {
        public static void Generate(int index, int[] arr)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    arr[index] = i;
                    Generate(index + 1, arr);
                }
            }

        }
        public static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            int[] arr = new int[num];
            Generate(0, arr);
        }
    }
}
