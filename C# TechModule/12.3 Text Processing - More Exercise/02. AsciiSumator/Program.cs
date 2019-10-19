namespace _02._AsciiSumator
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var beginning = char.Parse(Console.ReadLine());
            var end = char.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            var sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > beginning && input[i] < end)
                {
                    sum += input[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
