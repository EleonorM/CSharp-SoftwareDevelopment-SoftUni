namespace _03.CyclesInGraph
{
    using System.Collections.Generic;

    public class Node
    {
        public Node()
        {
            Children = new List<Node>();
        }

        public char Value { get; set; }

        public List<Node> Children { get; set; }
    }
}
