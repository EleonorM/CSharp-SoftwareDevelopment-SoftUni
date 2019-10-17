namespace _09.CustomLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private class ListNode
        {
            public T Value { get; set; }

            public ListNode Next { get; set; }

            public ListNode Previous { get; set; }

            public ListNode(T value)
            {
                this.Value = value;
            }
        }

        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFiirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                var newNode = new ListNode(element);
                var oldNode = this.head;
                newNode.Next = oldNode;
                this.head = newNode;
                this.head.Previous = newNode;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                var newNode = new ListNode(element);
                newNode.Previous = this.tail;
                this.tail.Next = newNode;
                this.tail = newNode;
            }

            Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List Empty");
            }

            var firstElement = this.head.Value;
            this.head = this.head.Next;
            if (this.head != null)
            {
                this.head.Previous = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List Empty");
            }

            var lastElement = this.tail.Value;
            this.tail = this.tail.Previous;
            if (this.tail != null)
            {
                this.tail.Next = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;
            return lastElement;
        }

        public void ForeEach(Action<T> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            var counter = 0;
            var currentNode = this.head;
            for (int i = 0; i < array.Length; i++)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.Next;
                counter++;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
