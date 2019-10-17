namespace _02.USD_to_BGN
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var USD = double.Parse(Console.ReadLine());
            var BGN = USD * 1.79549;
            Console.WriteLine($"{BGN:f2} BGN");
        }
    }
}
