namespace _01._PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<Tree<int>> nodeByValue = new List<Tree<int>>();

        public static void Main()
        {
            var linesToRead = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesToRead - 1; i++)
            {
                var nodes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                var parentValue = nodes[0];
                var childValue = nodes[1];

                var parentNode = GetThreeNodeByValue(parentValue);
                var childNode = GetThreeNodeByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            var pathSum = int.Parse(Console.ReadLine());
            var subtreeSum = int.Parse(Console.ReadLine());


            var rootNode = nodeByValue[0].FindRootNode();
            Console.WriteLine("Root node: " + rootNode.Value);

            var leafNodes = rootNode.FindLeafNodes().Select(x => x.Value).OrderBy(x => x).ToList();
            Console.WriteLine("Leaf nodes: " + string.Join(", ", leafNodes));

            var middleNodes = rootNode.FindMiddleNodes().Select(x => x.Value).OrderBy(x => x).ToList();
            Console.WriteLine("Middle nodes: " + string.Join(", ", middleNodes));

            var longestRoadNodes = rootNode.FindLongestRoadNodes().Select(x => x.Value).ToList();
            Console.WriteLine("Longest path: " + string.Join(" -> ", longestRoadNodes) + $" (length = {longestRoadNodes.Count})");

            var pathsOfSum = rootNode.FindPathsOfSum(pathSum).Select(x => x.Select(y => y.Value)).ToList();
            Console.WriteLine($"Paths of sum {pathSum}:");
            for (int i = 0; i < pathsOfSum.Count; i++)
            {
                Console.WriteLine(string.Join(" -> ", pathsOfSum[i]));
            }

            var subtreesOfSum = rootNode.FindSubtreesOfSum(subtreeSum).Select(x => x.Select(y => y.Value)).ToList();
            Console.WriteLine($"Subtrees of sum {subtreeSum}:");
            for (int i = 0; i < subtreesOfSum.Count; i++)
            {
                Console.WriteLine(string.Join(" + ", subtreesOfSum[i]));
            }
            Console.WriteLine();
        }

        private static Tree<int> GetThreeNodeByValue(int value)
        {
            if (!nodeByValue.Any(x => x.Value == value))
            {
                var newNode = new Tree<int>(value);
                nodeByValue.Add(newNode);
                return newNode;
            }
            else
            {
                var node = nodeByValue.FirstOrDefault(x => x.Value == value);
                return node;
            }
        }
    }
}
