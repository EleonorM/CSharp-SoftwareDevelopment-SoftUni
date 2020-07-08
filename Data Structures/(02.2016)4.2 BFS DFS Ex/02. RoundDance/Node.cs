namespace _02._RoundDance
{
    using System.Collections.Generic;

    internal class Node
    {
        public int Value { get; set; }

        public List<Node> Connections { get; set; }

        public Node(int value)
        {
            Value = value;
            Connections = new List<Node>();
        }

        internal int FindLongestPathDistance()
        {
            DFS(this, 0, this);
            return LongestDistance + 1;
        }

        private int LongestDistance = 0;

        private void DFS(Node node, int distance, Node prevNode)
        {
            if (distance > LongestDistance)
            {
                LongestDistance = distance;
            }

            foreach (var nodeConnection in node.Connections)
            {
                if (nodeConnection != prevNode)
                {
                    DFS(nodeConnection, distance + 1, node);
                }
            }
        }
    }
}