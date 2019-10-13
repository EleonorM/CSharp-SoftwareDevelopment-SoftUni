using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._8_Queens_Puzzle2
{
    class Program
    {
        static void PutQueens(int row, char[,] board)
        {
            bool IsFree = true;
            if (row == 8)
            {
                PrintSolution(board);
            }
            else
            {
                for (int col = 0; col <= 7; col++)
                {
                    if (CanPlaceQueen(row, col, board, IsFree) == true)
                    {
                        board[row, col] = '*';
                        PutQueens(row + 1, board);
                    }
                    //else
                    //{
                    //    board[row, col] = '_';
                    //}


                    //if (board[row, col] == '*')
                    //{
                    //    board[row, col] = '-';
                    //}

                }
            }
        }

        private static bool CanPlaceQueen(int row, int col, char[,] board, bool IsFree)
        {
            for (int i = 0; i < 8; i++)
            {
                if (board[col, i] == '*')
                {
                    return IsFree = false;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (board[i, row] == '*')
                {
                    return IsFree = false;
                }
            }
            if (row - col > 0)
            {
                for (int i = 0; i < 8 - row + col; i++)
                {
                    if (board[i, row - col + i] == '*')
                    {
                        return IsFree = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 8 + row - col; i++)
                {
                    if (board[i - row + col, i] == '*')
                    {
                        return IsFree = false;
                    }
                }
            }
            if (row + col <= 7)
            {
                for (int i = 0; i < 8 - row - col; i++)
                {

                    if (board[i, i + row + col] == '*')
                    {
                        return IsFree = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 8 - row - col + 7; i++)
                {
                    if (board[i + row + col - 7, i] == '*')
                    {
                        return IsFree = false;
                    }

                }
            }
            return IsFree = true;
        }

        private static void PrintSolution(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                   board[row, col] = '_';
                }
            }
            PutQueens(0, board);
            //char[,] boardTest = {{'1', '2', '3'},
            //    { '1','2','3'} };
            PrintSolution(board);
        }
    }
}
