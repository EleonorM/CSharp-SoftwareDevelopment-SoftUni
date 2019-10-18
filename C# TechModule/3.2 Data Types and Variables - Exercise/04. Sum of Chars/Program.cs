namespace _04._Sum_of_Chars
{
    using System;

    public class Program
    {
        public static void Main()
        {
            byte countNumbers = byte.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < countNumbers; i++)
            {
                char input = char.Parse(Console.ReadLine());
                sum += input;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
