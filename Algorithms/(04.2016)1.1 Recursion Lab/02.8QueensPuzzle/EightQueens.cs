namespace _02._8QueensPuzzle
{
    using System;

    class EightQueens
    {
        const int Size = 8;

        static bool[,] chessboard = new bool[Size, Size];

        public int SolutionsFound { get; private set; }

        static bool[] attackedColumns = new bool[Size];

        static bool[] attackedLeftDiagonals = new bool[Size * 2 - 1];

        static bool[] attackedRightDiagonals = new bool[Size * 2 - 1];

        public void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private void MarkAllAttackedPositions(int row, int col)
        {
            attackedColumns[col] = true;
            attackedLeftDiagonals[7 + col - row] = true;
            attackedRightDiagonals[col + row] = true;
            chessboard[row, col] = true;
        }

        private void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedColumns[col] = false;
            attackedLeftDiagonals[7 + col - row] = false;
            attackedRightDiagonals[col + row] = false;
            chessboard[row, col] = false;
        }

        private bool CanPlaceQueen(int row, int col)
        {
            var positionOccupied =
                attackedColumns[col] == true ||
                attackedLeftDiagonals[7 + col - row] == true ||
                attackedRightDiagonals[col + row] == true;

            return !positionOccupied;
        }

        private void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    var symbol = chessboard[row, col] == true ? '*' : '-';
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            SolutionsFound++;
        }
    }
}
