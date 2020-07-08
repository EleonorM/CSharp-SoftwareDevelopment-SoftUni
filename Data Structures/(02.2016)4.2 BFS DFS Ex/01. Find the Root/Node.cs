namespace _01._Find_the_Root
{
    using System.Collections.Generic;

    public class Node
    {
        public int Value { get; set; }

        public Node Parent { get; set; }

        public List<Node> Children { get; set; }
    }
}
