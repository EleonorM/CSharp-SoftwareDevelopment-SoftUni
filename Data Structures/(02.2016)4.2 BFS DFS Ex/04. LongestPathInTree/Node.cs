namespace _04._LongestPathInTree
{
    using System.Collections.Generic;

    public class Node
    {
        private int BiggestSum = 0;

        private Node LongestDistanceNode;

        public int Value { get; set; }

        public Node Parent { get; set; }

        public List<Node> Children { get; set; }

        public Node(int value = 0)
        {
            Value = value;
            Children = new List<Node>();
        }

        internal List<Node> FindLongestPathBySum()
        {
            DFS(this, 0);
            var nodesInPath = GetNodesInPath(LongestDistanceNode);
            BiggestSum = 0;
            DFSForSecondPath(this, 0, nodesInPath);
            var nodesInSecondPath = GetNodesInPath(LongestDistanceNode);
            nodesInSecondPath.Remove(this);
            nodesInPath.AddRange(nodesInSecondPath);
            return nodesInPath;
        }

        private void DFS(Node node, int sum)
        {
            sum += node.Value;

            foreach (var nodeConnection in node.Children)
            {
                DFS(nodeConnection, sum);
            }

            if (sum > BiggestSum && node.Children.Count == 0)
            {
                BiggestSum = sum;
                LongestDistanceNode = node;
            };
        }

        private List<Node> GetNodesInPath(Node longestDistanceNode)
        {
            var nodes = new List<Node>();

            var currentNode = longestDistanceNode;
            while (currentNode != null)
            {
                nodes.Add(currentNode);
                currentNode = currentNode.Parent;
            }

            return nodes;
        }


        private void DFSForSecondPath(Node node, int sum, List<Node> nodesToSkip)
        {
            sum += node.Value;

            foreach (var child in node.Children)
            {
                if (nodesToSkip.Contains(child))
                {
                    continue;
                }
                DFS(child, sum);
            }

            if (sum > BiggestSum && node.Children.Count == 0)
            {
                BiggestSum = sum;
                LongestDistanceNode = node;
            };
        }

    }
}
