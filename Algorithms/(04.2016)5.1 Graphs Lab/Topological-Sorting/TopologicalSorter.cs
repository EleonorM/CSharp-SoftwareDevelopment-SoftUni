using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public ICollection<string> TopSort()
    {
        var predecessorCount = new Dictionary<string, int>();
        foreach (var node in graph)
        {
            if (!predecessorCount.ContainsKey(node.Key))
            {
                predecessorCount.Add(node.Key, 0);
            }
            foreach (var childNode in node.Value)
            {
                if (!predecessorCount.ContainsKey(childNode))
                {
                    predecessorCount[childNode] = 0;
                }
                predecessorCount[childNode]++;
            }
        }

        var removedNodes = new List<string>();

        while (true)
        {
            var nodeToRemove = graph.Keys.FirstOrDefault(n => predecessorCount[n] == 0);
            if (nodeToRemove == null)
            {
                break;
            }

            removedNodes.Add(nodeToRemove);

            foreach (var child in this.graph[nodeToRemove])
            {
                predecessorCount[child]--;
            }
            this.graph.Remove(nodeToRemove);
        }

        if (graph.Count > 0)
        {
            throw new InvalidOperationException("A cycle detected in the graph");
        }

        return removedNodes;
    }
}
