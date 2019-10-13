namespace _01._Socks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var leftSocks = new List<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());
            var rightSocks = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList());
            var pairs = new List<int>();
            while (leftSocks.Count > 0 && rightSocks.Count > 0)
            {
                var currentLeftSock = leftSocks[leftSocks.Count - 1];
                var currentRightSock = rightSocks.Pop();

                if (currentRightSock > currentLeftSock)
                {
                    leftSocks.RemoveAt(leftSocks.Count - 1);
                    rightSocks.Push(currentRightSock);
                }
                else if (currentRightSock < currentLeftSock)
                {
                    currentLeftSock += currentRightSock;
                    pairs.Add(currentLeftSock);
                    leftSocks.RemoveAt(leftSocks.Count - 1);
                }
                else
                {
                    leftSocks[leftSocks.Count - 1]++;
                }
            }

            Console.WriteLine(pairs.OrderByDescending(x => x).FirstOrDefault());
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}
