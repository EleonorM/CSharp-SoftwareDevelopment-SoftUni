namespace _07.ImplementLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        public ListNode<T> first;
        public ListNode<T> last;

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentException();
            }

            if (first == null)
            {
                var newNode = new ListNode<T>(item);
                first = newNode;
                last = newNode;
            }
            else
            {
                var newNode = new ListNode<T>(item);
                last.Next = newNode;
                last = newNode;
            }

            Count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                throw new ArgumentException();
            }

            var current = first;
            var indexer = 0;
            ListNode<T> previous = null;
            while (current != null)
            {
                if (indexer == index)
                {
                    if (previous == null)
                    {
                        first = current.Next;
                    }

                    previous.Next = current.Next;
                }

                previous = current;
                current = current.Next;
                indexer++;
            }

            Count--;
        }

        public int FirstIndexOf(T item)
        {
            var current = first;
            var indexer = 0;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return indexer;
                }
                current = current.Next;
                indexer++;
            }

            throw new ArgumentException();
        }

        public int LastIndexOf(T item)
        {
            var current = first;
            var indexer = 0;
            var lastOccurance = -1;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    lastOccurance = indexer;
                }
                current = current.Next;
                indexer++;
            }


            if (lastOccurance == -1)
            {
                throw new ArgumentException();
            }

            return lastOccurance;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = first;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
