namespace _07.ConnectedAreasInAMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static char[,] field;
        private static List<Area> areas;

        public static void Main()
        {
            ReadInput();
            areas = new List<Area>();
            FindTraversableCellRecursion(0);
            Console.WriteLine($"Total areas found: {areas.Count}");
            areas = areas.OrderBy(x => x.PositionRow).ToList();
            for (int i = 0; i < areas.Count; i++)
            {
                CalculateSize(areas[i]);
            }
            areas = areas.OrderByDescending(x => x.Size).ToList();
            if (areas.Any(x => x.Size == 0))
            {
                var areaToRemove = areas.Where(x => x.Size == 0).ToList();
                foreach (var area in areaToRemove)
                {
                    areas.Remove(area);
                }
            }
            for (int i = 0; i < areas.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at ({areas[i].PositionRow}, {areas[i].PositionCol}), size: {areas[i].Size}");
            }
            Console.WriteLine();
        }

        private static void FindTraversableCellRecursion(int position)
        {
            if (position == field.GetLength(0))
            {
                return;
            }

            for (int i = 0; i < field.GetLength(1); i++)
            {
                var SearchedCell = FindTraversableCell(position, i);
                if (SearchedCell == null)
                {
                    FindTraversableCellRecursion(position + 1);
                }
                else
                {
                    var area = new Area() { PositionCol = SearchedCell[1], PositionRow = SearchedCell[0] };
                    areas.Add(area);
                    continue;
                }
            }
        }

        private static int[] FindTraversableCell(int row, int col)
        {
            if (field[row, col] == '*')
            {
                return null;
            }

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
                {
                    return new int[] { row, col };
                }
            }
            else if (IsInside(row, col - 1)
                && field[row, col - 1] == '*'
                && IsInside(row - 1, col)
                && field[row - 1, col] == '*')
            {
                if (!ChekIfVisited(row, col))
                {
                    return new int[] { row, col };
                }
            }
            else if (IsInside(row - 1, col)
                && field[row - 1, col] == '*'
                && !IsInside(row, col - 1))
            {
                if (!ChekIfVisited(row, col))
                {
                    return new int[] { row, col };
                }
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

        public static void CalculateSize(Area area)
        {
            MoveDirections(area.PositionRow, area.PositionCol, area);
        }

        private static void MoveDirections(int row, int col, Area area)
        {
            if (CanContiniue(row, col + 1))
            {
                MarkVisitedCell(row, col + 1);
                area.Size++;
                MoveDirections(row, col + 1, area);

            }

            if (CanContiniue(row, col - 1))
            {
                MarkVisitedCell(row, col - 1);
                area.Size++;
                MoveDirections(row, col - 1, area);

            }

            if (CanContiniue(row + 1, col))
            {
                MarkVisitedCell(row + 1, col);
                area.Size++;
                MoveDirections(row + 1, col, area);
            }

            if (CanContiniue(row - 1, col))
            {
                MarkVisitedCell(row - 1, col);
                area.Size++;
                MoveDirections(row - 1, col, area);
            }
        }

        private static void MarkVisitedCell(int row, int col) => field[row, col] = '-';

        private static bool CanContiniue(int row, int col) => IsInside(row, col) && field[row, col] == ' ';
    }
}
