namespace _04.TowersofHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int stepsTaken;
        private static Stack<int> source;
        private static Stack<int> destination = new Stack<int>();
        private static Stack<int> spare = new Stack<int>();

        public static void Main()
        {
            var numberOfDiks = int.Parse(Console.ReadLine());
            source = new Stack<int>(Enumerable.Range(1,numberOfDiks).Reverse());
            PrintPegs();

            MoveDisks(numberOfDiks, source, destination, spare);
        }

        private static void PrintPegs()
        {
            Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
            Console.WriteLine();
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                stepsTaken++;
                destination.Push(source.Pop());
                Console.WriteLine($"Step #{stepsTaken}: Moved disk");
                PrintPegs();
            }
            else
            {
                MoveDisks(bottomDisk-1, source, spare, destination);
                stepsTaken++;
                destination.Push(source.Pop());
                Console.WriteLine($"Step #{stepsTaken}: Moved disk");
                PrintPegs();
                MoveDisks(bottomDisk-1, spare, destination, source);
            }
        }
    }
}
