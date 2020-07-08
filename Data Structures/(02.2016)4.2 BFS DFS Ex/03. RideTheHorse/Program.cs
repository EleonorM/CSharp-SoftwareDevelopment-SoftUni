namespace _03._RideTheHorse
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var height = int.Parse(Console.ReadLine());
            var width = int.Parse(Console.ReadLine());
            var chessTable = new ChessTable(height, width);

            var heightStart = int.Parse(Console.ReadLine());
            var widthEnd = int.Parse(Console.ReadLine());
            var positionStart = new Position(heightStart, widthEnd);

            chessTable.Move(positionStart);

            chessTable.PrintMiddleColumn();
        }
    }
}
