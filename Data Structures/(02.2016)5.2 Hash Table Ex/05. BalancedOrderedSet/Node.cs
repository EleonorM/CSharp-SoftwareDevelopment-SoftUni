namespace _05._BalancedOrderedSet
{
    public class Node<T>
    {
        private int height;

        public T Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public Node<T> Parent { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public int Height()
        {
            height = 0;
            DFS(this, 0);
            return height;
        }

        private void DFS(Node<T> node, int counter)
        {
            counter++;
            if (node.Left != null)
            {
                DFS(node.Left, counter);
            }

            if (node.Right != null)
            {
                DFS(node.Right, counter);
            }

            if (counter > height)
            {
                height = counter;
            }
        }
    }
}
