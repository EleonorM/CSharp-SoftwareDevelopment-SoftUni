namespace _04._LongestPathInTree
{
    using System.Collections.Generic;

    public class Node
    {
        public int Value { get; set; }

        public List<Node> Children { get; set; }

        public Node Parent { get; set; }

        public int BiggestSum { get; set; }

        public int SecondBiggestSum { get; set; }

        public Node(int value = 0)
        {
            Value = value;
            Children = new List<Node>();
        }

        internal int FindLongestPathBySum()
        {
            DFS(this, 0);
            var sumLongestPath = this.BiggestSum + this.SecondBiggestSum + this.Value;
            return sumLongestPath;
        }

        private void DFS(Node node, int sum)
        {
            sum += node.Value;

            foreach (var child in node.Children)
            {
                DFS(child, sum);
                if (child.BiggestSum + child.Value > node.BiggestSum)
                {
                    node.SecondBiggestSum = node.BiggestSum;
                    node.BiggestSum = child.BiggestSum + child.Value;
                }
            }
        }
    }
}
