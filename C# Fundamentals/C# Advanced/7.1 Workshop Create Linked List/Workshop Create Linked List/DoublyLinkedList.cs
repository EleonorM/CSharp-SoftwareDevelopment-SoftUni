using System;

namespace Workshop_Create_Linked_List
{


    class DoublyLinkedList
    {
        private class ListNode
        {
            public int Value { get; set; }

            public ListNode Next { get; set; }

            public ListNode Previous { get; set; }

            public ListNode(int value)
            {
                this.Value = value;
            }
        }

        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                var newNode = new ListNode(element);
                newNode.Next = this.head;
                this.head.Previous = newNode;
                this.head = newNode;
            }

            this.Count++;
        }

        public void AddLast(int element)
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

        public int RemoveFirst()
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

        public int RemoveLast()
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

        public void ForEach(Action<int> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];
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
    }
}
