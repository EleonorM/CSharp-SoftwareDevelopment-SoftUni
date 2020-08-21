namespace _03.CyclesInGraph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<Node> graph;

        private static HashSet<char> visited;

        private static bool isAcrylic;

        public static void Main()
        {
            ReadInput();
            visited = new HashSet<char>();
            isAcrylic = true;
            DFS(graph[0], graph[0]);
            var isAcrylicAddition = isAcrylic ? "Yes" : "No";
            Console.WriteLine($"Acyclic: {isAcrylicAddition}");
        }

        private static void DFS(Node node, Node parentNode)
        {
            if (visited.Contains(node.Value))
            {
                isAcrylic = false;
                return;
            }

            visited.Add(node.Value);
            foreach (var child in node.Children)
            {
                if (parentNode != child)
                {
                    DFS(child, node);
                }
            }
        }

        private static void ReadInput()
        {
            graph = new List<Node>();
            var input = Console.ReadLine();
            while (input != "End")
            {
                var link = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                var letter = char.Parse(link[0]);
                var connectedLetter = char.Parse(link[1]);
                var connectedNode = graph.FirstOrDefault(x => x.Value == connectedLetter);
                if (connectedNode == null)
                {
                    connectedNode = new Node() { Value = connectedLetter };
                    graph.Add(connectedNode);
                }

                if (!graph.Any(x => x.Value == letter))
                {
                    graph.Add(new Node() { Value = letter });
                }

                var node = graph.FirstOrDefault(x => x.Value == letter);
                node.Children.Add(connectedNode);
                connectedNode.Children.Add(node);
                input = Console.ReadLine();
            }
        }
    }
}
