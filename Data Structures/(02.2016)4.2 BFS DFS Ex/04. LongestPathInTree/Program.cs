namespace _04._LongestPathInTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<Node> nodes;

        public static void Main()
        {
            nodes = new List<Node>();

            var allNodes = int.Parse(Console.ReadLine());
            var linesToRead = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesToRead; i++)
            {
                var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                var parent = input[0];
                var parentNode = nodes.FirstOrDefault(x => x.Value == parent);
                if (parentNode == null)
                {
                    parentNode = new Node(parent);
                    nodes.Add(parentNode);
                }

                var child = input[1];
                var childNode = nodes.FirstOrDefault(x => x.Value == child);
                if (childNode == null)
                {
                    childNode = new Node(child);
                    nodes.Add(childNode);
                }

                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            var root = FindRoot();
           var nodesInPath = root.FindLongestPathBySum();
            Console.WriteLine(nodesInPath.Select(x => x.Value).Sum());
        }

        private static Node FindRoot()
        {
            var root = nodes.FirstOrDefault(x => x.Parent == null);
            return root;
        }

    }
}
