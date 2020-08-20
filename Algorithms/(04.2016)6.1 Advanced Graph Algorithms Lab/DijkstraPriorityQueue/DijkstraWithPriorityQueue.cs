namespace Dijkstra
{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithPriorityQueue
    {
        public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
        {
            var prev = new int?[graph.Count];
            var visited = new bool[graph.Count];

            var priorityQueue = new PriorityQueue<Node>();

            foreach (var pair in graph)
            {
                pair.Key.DistanceFromStart = double.PositiveInfinity;
            }

            sourceNode.DistanceFromStart = 0;
            priorityQueue.Enqueue(sourceNode);

            while (priorityQueue.Count > 0)
            {
                var currentNode = priorityQueue.ExtractMin();
                visited[currentNode.Id] = true;

                if (currentNode == destinationNode)
                {
                    break;
                }

                foreach (var node in graph[currentNode])
                {
                    if (!visited[node.Key.Id])
                    {
                        priorityQueue.Enqueue(node.Key);
                        visited[node.Key.Id] = true;
                    }

                    var newDistance = currentNode.DistanceFromStart + node.Value;
                    if (newDistance < node.Key.DistanceFromStart)
                    {
                        node.Key.DistanceFromStart = newDistance;
                        prev[node.Key.Id] = currentNode.Id;
                        priorityQueue.DecreaseKey(node.Key);
                    }
                }
            }

            if (double.IsInfinity(destinationNode.DistanceFromStart))
            {
                return null;
            }

            List<int> path = new List<int>();
            int? current = destinationNode.Id;
            while (current != null)
            {
                path.Add(current.Value);
                current = prev[current.Value];
            }

            path.Reverse();
            return path;
        }
    }
}
