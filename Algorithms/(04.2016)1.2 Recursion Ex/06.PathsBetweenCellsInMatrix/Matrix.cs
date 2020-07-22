namespace _06.PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;

    public class Matrix
    {
        private char[,] matrix;
        private List<char> list;
        private List<string> paths;

        public Matrix(int rows, int cols)
        {
            matrix = new char[rows, cols];
            list = new List<char>();
            paths = new List<string>();
        }
        public char this[int row, int column]
        {
            get
            {
                if (!IsInside(row, column))
                {
                    throw new ArgumentException();
                }
                return matrix[row, column];
            }

            set
            {
                if (!IsInside(row, column))
                {
                    throw new ArgumentException();
                }
                matrix[row, column] = value;
            }
        }

        public List<string> Move(int row, int col)
        {
            MoveDirections(row, col);
            return paths;
        }

        private void MoveDirections(int row, int col)
        {

            if (CanContiniue(row, col + 1))
            {
                list.Add('R');
                if (matrix[row, col + 1] == 'e')
                {
                    paths.Add(string.Concat(list));
                }
                else
                {
                    MarkVisitedCell(row, col + 1);
                    MoveDirections(row, col + 1);
                    UnmarkVisitedCell(row, col + 1);
                }

                list.RemoveAt(list.Count - 1);
            }

            if (CanContiniue(row, col - 1))
            {
                list.Add('L');
                if (matrix[row, col - 1] == 'e')
                {
                    paths.Add(string.Concat(list));
                }
                else
                {
                    MarkVisitedCell(row, col - 1);
                    MoveDirections(row, col - 1);
                    UnmarkVisitedCell(row, col - 1);
                }

                list.RemoveAt(list.Count - 1);
            }

            if (CanContiniue(row + 1, col))
            {
                list.Add('D');
                if (matrix[row + 1, col] == 'e')
                {
                    paths.Add(string.Concat(list));
                }
                else
                {
                    MarkVisitedCell(row + 1, col);
                    MoveDirections(row + 1, col);
                    UnmarkVisitedCell(row + 1, col);
                }

                list.RemoveAt(list.Count - 1);
            }

            if (CanContiniue(row - 1, col))
            {
                list.Add('U');
                if (matrix[row - 1, col] == 'e')
                {
                    paths.Add(string.Concat(list));

                }
                else
                {
                    MarkVisitedCell(row - 1, col);
                    MoveDirections(row - 1, col);
                    UnmarkVisitedCell(row - 1, col);
                }

                list.RemoveAt(list.Count - 1);
            }
        }

        private void MarkVisitedCell(int row, int col) => matrix[row, col] = '-';

        private void UnmarkVisitedCell(int row, int col) => matrix[row, col] = ' ';

        private bool CanContiniue(int row, int col) => IsInside(row, col) && (matrix[row, col] == ' ' || matrix[row, col] == 'e');

        public bool IsInside(int row, int col)
        {
            if (row < 0 || row > matrix.GetLongLength(0) - 1)
            {
                return false;
            }

            if (col < 0 || col > matrix.GetLongLength(1) - 1)
            {
                return false;
            }

            return true;
        }
    }
}
