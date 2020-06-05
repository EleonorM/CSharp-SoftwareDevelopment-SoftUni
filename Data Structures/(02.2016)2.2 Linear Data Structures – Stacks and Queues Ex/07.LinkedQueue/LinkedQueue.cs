namespace _07.LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private QueueNode<T> head;

        private QueueNode<T> tail;

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (Count == 0)
            {
                var node = new QueueNode<T>(element);
                head = tail = node;
            }
            else
            {
                var node = new QueueNode<T>(element);
                node.PrevNode = tail;
                tail.NextNode = node;
                tail = node;
            }

            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var node = head;
            head = node.NextNode;
            Count--;

            return node.Value;
        }
        public T[] ToArray()
        {
            var arr = new T[Count];

            var currentNode = this.head;
            var counter = 0;
            while (currentNode != null)
            {
                arr[counter] = currentNode.Value;
                currentNode = currentNode.NextNode;
                counter++;
            }

            return arr;
        }

        private class QueueNode<T>
        {
            public T Value { get; private set; }

            public QueueNode<T> NextNode { get; set; }

            public QueueNode<T> PrevNode { get; set; }

            public QueueNode(T value)
            {
                Value = value;
            }
        }

    }
}
