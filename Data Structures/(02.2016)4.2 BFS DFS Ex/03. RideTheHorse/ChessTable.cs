namespace _03._RideTheHorse
{
    using System;
    using System.Collections.Generic;

    public class ChessTable
    {
        public int Height { get; set; }

        public int Width { get; set; }

        private int[,] table;

        static Move UpRight1 = new Move { Vertical = -2, Horizontal = 1 };
        static Move UpRight2 = new Move { Vertical = -1, Horizontal = 2 };

        static Move UpLeft1 = new Move { Vertical = -2, Horizontal = -1 };
        static Move UpLeft2 = new Move { Vertical = -1, Horizontal = -2 };

        static Move DownRight1 = new Move { Vertical = 2, Horizontal = 1 };
        static Move DownRight2 = new Move { Vertical = 1, Horizontal = 2 };

        static Move DownLeft1 = new Move { Vertical = 2, Horizontal = -1 };
        static Move DownLeft2 = new Move { Vertical = 1, Horizontal = -2 };

        static List<Move> moves;


        public ChessTable(int height, int width)
        {
            Height = height;
            Width = width;
            this.table = new int[Height, Width];
            GenerateMoves();
        }

        static void GenerateMoves()
        {
            moves = new List<Move>();
            moves.Add(UpRight1);
            moves.Add(UpRight2);
            moves.Add(UpLeft1);
            moves.Add(UpLeft2);
            moves.Add(DownRight1);
            moves.Add(DownRight2);
            moves.Add(DownLeft1);
            moves.Add(DownLeft2);
        }

        public void Move(Position position)
        {
            var queue = new Queue<Position>();
            queue.Enqueue(position);
            while (queue.Count != 0)
            {
                var currentPosition = queue.Dequeue();
                foreach (var move in moves)
                {
                    MoveHorseInCertainPosition(currentPosition, move, queue);
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void PrintMiddleColumn()
        {
            for (int i = 0; i < Height; i++)
            {
                Console.WriteLine(table[i, Width / 2] + " ");
            }
        }

        private void MoveHorseInCertainPosition(Position position, Move move, Queue<Position> queue)
        {
            table[position.Height, position.Width] = position.StepsToPosition;
            var newPosition = new Position(position.Height + move.Vertical, position.Width + move.Horizontal);
            newPosition.StepsToPosition = position.StepsToPosition + 1;

            if (IsInTable(newPosition.Height, newPosition.Width))
            {
                if (table[newPosition.Height, newPosition.Width] != 0)
                {
                    return;
                }
                queue.Enqueue(newPosition);
            }

        }

        private bool IsInTable(int height, int width)
        {
            if (0 <= height && height < Height && 0 <= width && width < Width)
            {
                return true;
            }

            return false;
        }
    }
}
