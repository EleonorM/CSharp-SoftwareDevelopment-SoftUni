namespace _01._Find_the_Root
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<Node> nodes;

        public static void Main()
        {
            ReadInput();
            var roots = FindRoot();
            PrintOutput(roots);

        }

        private static void ReadInput()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());
            CreateInitialNodes(numberOfNodes);

            for (int i = 0; i < edges; i++)
            {
                var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                var parentNode = input[0];
                var childNode = input[1];
                nodes[parentNode].Children.Add(nodes[childNode]);
                nodes[childNode].Parent = nodes[parentNode];
            }
        }

        private static void CreateInitialNodes(int numberOfNodes)
        {
            nodes = new List<Node>();
            for (int i = 0; i < numberOfNodes; i++)
            {
                nodes.Add(new Node { Value = i, Children = new List<Node>() });
            }
        }

        private static List<Node> FindRoot()
        {
            var roots = nodes.Where(x => x.Parent == null).ToList();
            return roots;
        }

        private static void PrintOutput(List<Node> roots)
        {
            if (roots.Count == 1)
            {
                Console.WriteLine(roots[0].Value);
            }
            else if (roots.Count > 1)
            {
                Console.WriteLine("Multiple root nodes!");
            }
            else
            {
                Console.WriteLine("No root!");
            }
        }
    }
}
