namespace _08._Distance_in_Labyrinth
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static int height;

        private static int width;

        private static string[,] labyrinth;

        private static string StartChar = "*";

        public static void Main(string[] args)
        {
            ReadLabyrinth();
            FillDistanceNumbersFromStart();
        }

        private static void ReadLabyrinth()
        {
            height = int.Parse(Console.ReadLine());
            width = int.Parse(Console.ReadLine());
            labyrinth = new string[width, height];

            for (int row = 0; row < height; row++)
            {
                var input = Console.ReadLine();
                var inputChar = input.ToCharArray();
                for (int column = 0; column < inputChar.Length; column++)
                {
                    labyrinth[column, row] = inputChar[column].ToString();
                }
            }
        }

        private static void FillDistanceNumbersFromStart()
        {
            var startPoint = FindStartPoint();
            if (startPoint == null)
            {
                return;
            }

            var queue = new Queue<Point>();
            var distance = 1;
            queue.Enqueue(startPoint);
            while (queue.Count != 0)
            {
                var currentCell = queue.Dequeue();
                if (currentCell.Distance > distance)
                {
                    distance++;
                }

                TryDirection(queue, currentCell, distance, 0, -1);
                TryDirection(queue, currentCell, distance, 0, 1);
                TryDirection(queue, currentCell, distance, -1, 0);
                TryDirection(queue, currentCell, distance, 1, 0);

            }

            FillUnreachableCells();
            PrintLabyrinth();
        }

        private static Point FindStartPoint()
        {
            for (int row = 0; row < width; row++)
            {
                for (int column = 0; column < height; column++)
                {
                    if (labyrinth[column, row] == StartChar)
                    {
                        return new Point { X = column, Y = row };
                    }
                }
            }

            return null;
        }

        private static void TryDirection(Queue<Point> queue, Point currentCell, int distance, int x, int y)
        {
            int newX = currentCell.X + x;
            int newY = currentCell.Y + y;

            if (newX >= 0 && newX < width && newY >= 0 && newY < height && labyrinth[newX, newY] == "0")
            {
                labyrinth[newX, newY] = distance.ToString();

                var nextCell = new Point
                {
                    X = newX,
                    Y = newY,
                    Distance = distance + 1,
                };

                queue.Enqueue(nextCell);
            }
        }

        private static void FillUnreachableCells()
        {
            for (int row = 0; row < width; row++)
            {
                for (int column = 0; column < height; column++)
                {
                    if (labyrinth[column, row] == "0")
                    {
                        labyrinth[column, row] = "u";
                    }
                }
            }
        }

        private static void PrintLabyrinth()
        {
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    Console.Write(labyrinth[column, row] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
