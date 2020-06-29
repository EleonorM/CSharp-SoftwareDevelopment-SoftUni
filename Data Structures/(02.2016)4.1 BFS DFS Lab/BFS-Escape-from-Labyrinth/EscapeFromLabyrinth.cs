using System;
using System.Collections.Generic;
using System.Text;

public class EscapeFromLabyrinth
{
    static int width;

    static int heigth;

    static char[,] labirinth;
    public static void Main()
    {
        ReadLabirinth();
        var path = FindShortestPathToExit();
        PrintPath(path);
    }

    private static void PrintPath(string path)
    {
        if (path == null)
        {
            Console.WriteLine("No exit!");
        }
        else if (path == "")
        {
            Console.WriteLine("Start is at the exit.");
        }
        else
        {
            Console.WriteLine("Shortest exit: " + path);
        }
    }

    private static void ReadLabirinth()
    {
        width = int.Parse(Console.ReadLine());
        heigth = int.Parse(Console.ReadLine());
        labirinth = new char[width, heigth];

        for (int row = 0; row < heigth; row++)
        {
            var input = Console.ReadLine();
            var rowInput = input.ToCharArray();
            for (int column = 0; column < rowInput.Length; column++)
            {

                labirinth[column, row] = rowInput[column];
            }
        }
    }

    class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public string Direction { get; set; }

        public Point PrevPoint { get; set; }
    }

    static char StartPointCell = 's';

    static char VisitedCell = 'v';

    private static string FindShortestPathToExit()
    {
        var queue = new Queue<Point>();
        var startPoint = FindStartPoint();
        if (startPoint == null)
        {
            return null;
        }

        queue.Enqueue(startPoint);
        while (queue.Count != 0)
        {
            var currentCell = queue.Dequeue();
            if (ItIsOnBorder(currentCell))
            {
                return TraceBackPath(currentCell);
            }

            TryDirection(queue, currentCell, "U", 0, -1);
            TryDirection(queue, currentCell, "D", 0, 1);
            TryDirection(queue, currentCell, "L", -1, 0);
            TryDirection(queue, currentCell, "R", 1, 0);
        }

        return null;
    }

    private static void TryDirection(Queue<Point> queue, Point currentCell, string direction, int x, int y)
    {
        int newX = currentCell.X + x;
        int newY = currentCell.Y + y;

        if (newX >= 0 && newX < width && newY >= 0 && newY < heigth && labirinth[newX, newY] == '-')
        {
            labirinth[newX, newY] = VisitedCell;

            var nextCell = new Point
            {
                X = newX,
                Y = newY,
                PrevPoint = currentCell,
                Direction = direction,
            };
            queue.Enqueue(nextCell);
        }
    }

    private static string TraceBackPath(Point currentCell)
    {
        var path = new List<string>();
        while (currentCell.PrevPoint != null)
        {
            path.Add(currentCell.Direction);
            currentCell = currentCell.PrevPoint;
        }

        path.Reverse();
        var pathAsString = new StringBuilder();
        foreach (var diretion in path)
        {
            pathAsString.Append(diretion);
        }

        return pathAsString.ToString().TrimEnd();
    }

    private static bool ItIsOnBorder(Point currentCell)
    {
        var isOnBorderX = currentCell.X == 0 || currentCell.X == width - 1;
        var isOnBorderY = currentCell.Y == 0 || currentCell.Y == heigth - 1;
        return isOnBorderX || isOnBorderY;
    }

    private static Point FindStartPoint()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < heigth; j++)
            {
                if (labirinth[i, j] == StartPointCell)
                {
                    return new Point { X = i, Y = j };
                }
            }
        }

        return null;
    }
}
