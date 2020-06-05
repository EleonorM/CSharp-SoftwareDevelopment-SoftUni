namespace _05.LinkedStack
{
    using System;

    public class LinkedStack<T>
    {
        private Node<T> firstNode = null;

        public int Count { get; private set; }

        public void Push(T element)
        {
            var node = new Node<T>(element, firstNode);
            this.firstNode = node;
            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var node = firstNode;
            this.firstNode = node.NextNode;
            Count--;
            return node.Value;
        }

        public T[] ToArray()
        {
            var array = new T[Count];
            var counter = 0;
            var currentNode = firstNode;
            while (currentNode != null)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.NextNode;
                counter++;
            }

            return array;
        }

        private class Node<T>
        {
            public T Value;

            public Node<T> NextNode { get; set; }

            public Node(T value, Node<T> nextNode = null)
            {
                Value = value;
                NextNode = nextNode;
            }
        }
    }
}
