namespace Kurskal
{
    using System;
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            edges.Sort();
            var parent = new int[numberOfVertices];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }

            var spanningTree = new List<Edge>();

            foreach (var edge in edges)
            {
                var rootStartNode = FindRoot(edge.StartNode, parent);
                var rootEndNode = FindRoot(edge.EndNode, parent);

                if (rootStartNode != rootEndNode)
                {
                    spanningTree.Add(edge);
                    parent[rootEndNode] = parent[rootStartNode];
                }
            }

            return spanningTree;
        }

        public static int FindRoot(int node, int[] parent)
        {
            var root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }

            while (root != node)
            {
                var oldNode = parent[node];
                parent[node] = root;
                node = oldNode;
            }

            return root;
        }
    }
}
