namespace _5._Snake_Moves
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new char[dimentions[0], dimentions[1]];
            var snake = Console.ReadLine().ToCharArray();
            var counter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(snake[counter]);
                    counter++;
                    if (snake.Length == counter)
                    {
                        counter = 0;
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
