using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    static new List<int>[] graph = new List<int>[]
             {
            new List<int>(){3,6},
            new List<int>(){3,4,5,6},
            new List<int>(){8},
            new List<int>(){0,1,5},
            new List<int>(){1,6},
            new List<int>(){1,3},
            new List<int>(){0,1,4},
            new List<int>(){},
            new List<int>(){2}
             };

    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }
    private static List<int>[] ReadGraph()
    {
        var n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            var nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            graph[i] = nums;
        }
        return graph;
    }

    private static void FindGraphConnectedComponents()
    {
        isVisited = new bool[graph.Length];
        var lastCheckedNode = 0;
        if (graph.Length == 0)
        {
            Console.Write("");
            return;
        }
        do
        {
            var sequence = new List<int>();
            DFS(lastCheckedNode, ref sequence);
            if (sequence.Count != 0)
            {
                PrintNodes(sequence);
            }

            lastCheckedNode++;
        } while (lastCheckedNode != graph.Length);

    }

    static bool[] isVisited;

    static void DFS(int node, ref List<int> sequence)
    {
        if (!isVisited[node])
        {
            isVisited[node] = true;
            foreach (var childNode in graph[node])
            {
                DFS(childNode, ref sequence);
            }
            sequence.Add(node);

        }
    }

    private static void PrintNodes(List<int> nodes)
    {
        Console.WriteLine("Connected component: " + string.Join(" ", nodes));
    }
}
