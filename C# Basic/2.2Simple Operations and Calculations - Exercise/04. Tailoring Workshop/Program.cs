namespace _04.Tailoring_Workshop
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var numberOfTables = int.Parse(Console.ReadLine());
            var lenghtTable = double.Parse(Console.ReadLine());
            var widthTable = double.Parse(Console.ReadLine());

            var sizeSquare = Math.Pow(lenghtTable / 2.0, 2);
            var sizeCover = (lenghtTable + 2 * 0.3) * (widthTable + 2 * 0.3);
            var costSquare = sizeSquare * 9 * numberOfTables;
            var costCover = sizeCover * 7 * numberOfTables;
            Console.WriteLine($"{costCover + costSquare:f2} USD");
            Console.WriteLine($"{(costCover + costSquare) * 1.85:f2} BGN");
        }
    }
}
