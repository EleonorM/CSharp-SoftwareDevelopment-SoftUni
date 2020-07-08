namespace _02._RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<Node> nodes;

        public static void Main()
        {
            var rootNodeValue = ReadInput();
            var rootNode = nodes.FirstOrDefault(x => x.Value == rootNodeValue);
            var path = rootNode.FindLongestPathDistance();
            Console.WriteLine(path);
        }

        private static int ReadInput()
        {
            var inputLines = int.Parse(Console.ReadLine());
            var startingNode = int.Parse(Console.ReadLine());

            nodes = new List<Node>();
            for (int i = 0; i < inputLines; i++)
            {
                var line = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                var firstNum = line[0];
                var secondNum = line[1];
                var firstNode = nodes.FirstOrDefault(x => x.Value == firstNum);
                if (firstNode == null)
                {
                    var node = new Node(firstNum);
                    firstNode = node;
                    nodes.Add(firstNode);
                }

                var secondNode = nodes.FirstOrDefault(x => x.Value == secondNum);
                if (secondNode == null)
                {
                    var node = new Node(secondNum);
                    secondNode = node;
                    nodes.Add(secondNode);
                }

                firstNode.Connections.Add(secondNode);
                secondNode.Connections.Add(firstNode);
            }

            return startingNode;
        }
    }
}
