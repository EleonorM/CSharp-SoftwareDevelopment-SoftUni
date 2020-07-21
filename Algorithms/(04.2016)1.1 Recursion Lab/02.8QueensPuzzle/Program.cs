namespace _02._8QueensPuzzle
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var queenBoard = new EightQueens();
            queenBoard.PutQueens(0);
            Console.WriteLine(queenBoard.SolutionsFound);
        }
    }
}
