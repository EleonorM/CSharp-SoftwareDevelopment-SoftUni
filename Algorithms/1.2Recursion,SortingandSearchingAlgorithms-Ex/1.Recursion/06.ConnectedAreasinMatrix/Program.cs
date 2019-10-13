using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ConnectedAreasinMatrix
{
    class Program
    {
        private static char[,] field;
        private static List<Area> areas;

        static void Main(string[] args)
        {
            ReadInput();
            areas = new List<Area>();
            FindTraversableCellRecursion(0);
            Console.WriteLine();
        }

        private static void FindTraversableCellRecursion(int position)
        {
            if (position == field.GetLength(1))
            {
                return;
            }

            for (int i = 0; i < field.GetLength(0); i++)
            {
                var SearchedCell = FindTraversableCell(i, position);
                if (SearchedCell == null)
                {
                    FindTraversableCellRecursion(position + 1);
                }
                else
                {
                    var area = new Area() { PositionCol = SearchedCell[1], PositionRow = SearchedCell[0] };
                   areas.Add(area);
                    Console.WriteLine(area.PositionRow+" "+area.PositionCol);
                    continue;
                }
            }
        }

        private static int[] FindTraversableCell(int row, int col)
        {
            if (!IsInside(row - 1, col)
                && !IsInside(row, col - 1))
            {
                if (!ChekIfVisited(row, col))
                {
                    return new int[] { row, col };
                }
            }
            else if (IsInside(row, col - 1)
                && field[row, col - 1] == '*'
                && !IsInside(row - 1, col))
            {
                if (!ChekIfVisited(row, col))
                { return new int[] { row, col }; }
            }
            else if (IsInside(row, col - 1)
                && field[row, col - 1] == '*'
                && IsInside(row - 1, col)
                && field[row - 1, col] == '*')
            {
                if (!ChekIfVisited(row, col))
                { return new int[] { row, col }; }
            }
            else if (IsInside(row - 1, col) 
                && field[row - 1, col] == '*' 
                && !IsInside(row, col - 1))
            {
                if (!ChekIfVisited(row, col))
                { return new int[] { row, col }; }
            }
            return null;
        }

        private static bool ChekIfVisited(int row, int col)
        {
            bool IsVisited = areas.Any(x => x.PositionRow == row && x.PositionCol == col);


            return IsVisited;
        }

        private static void ReadInput()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            field = new char[rows, cols];
            for (int row = 0; row < field.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];
                }
            }
        }

        private static bool IsInside(int desiredRow, int desiredCol)
        {
            return desiredRow < field.GetLength(0) && desiredRow >= 0
                && desiredCol < field.GetLength(1) && desiredCol >= 0;
        }
    }

    public class Area : IComparable
    {
        public int PositionRow { get; set; }

        public int PositionCol { get; set; }

        public int Size { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            var area = obj as Area;
            return Size.CompareTo(area.Size);
        }
    }
}
