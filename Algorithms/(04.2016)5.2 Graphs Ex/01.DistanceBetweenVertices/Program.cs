namespace _01.DistanceBetween_Vertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static Queue<Node> queue;
        private static HashSet<int> visited;

        static void Main(string[] args)
        {
            graph = new Dictionary<int, List<int>>();
            var input = Console.ReadLine();
            input = Console.ReadLine();
            while (input != "Distances to find:")
            {
                var link = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                var num = int.Parse(link[0]);
                graph[num] = new List<int>();
                if (link.Length > 1)
                {
                    var nums = link[1].Split(", ").Select(int.Parse).ToList();
                    graph[num].AddRange(nums);
                }

                input = Console.ReadLine();
            }
            while (input != "end")
            {
                input = Console.ReadLine();
                var distanceToFind = input.Split("-").Select(int.Parse).ToArray();
                Console.WriteLine($"{{{distanceToFind[0]}, {distanceToFind[1]}}} -> {CalculateDistance(distanceToFind[0], distanceToFind[1])}");
            }
        }

        private static int CalculateDistance(int from, int to)
        {
            queue = new Queue<Node>();
            queue.Enqueue(new Node() { Value = from, Distance = 0 });
            visited = new HashSet<int>();
            visited.Add(from);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode.Value == to)
                {
                    return currentNode.Distance;
                }

                foreach (var childNodeValue in graph[currentNode.Value])
                {
                    if (!visited.Contains(childNodeValue))
                    {
                        queue.Enqueue(new Node() { Value = childNodeValue, Distance = currentNode.Distance + 1 });
                        visited.Add(childNodeValue);
                    }
                }
            }

            return -1;
        }
    }
}
