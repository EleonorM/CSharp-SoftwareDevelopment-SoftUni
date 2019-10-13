using System;
using System.Linq;

public class LinkedQueue<T>
{
    private QueueNode<T> head;
    private QueueNode<T> tail;

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new QueueNode<T>(element);
        }
        else
        {
            var newNode = new QueueNode<T>(element);
            newNode.NextNode = this.head;
            this.head.PrevNode = newNode;
            this.head = newNode;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        var lastElement = this.tail.Value;
        this.tail = this.tail.PrevNode;
        if (this.tail != null)
        {
            this.tail.NextNode = null;
        }
        else
        {
            this.head = null;
        }

        this.Count--;
        return lastElement;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        var counter = 0;
        var currentNode = this.head;
        for (int i = 0; i < array.Length; i++)
        {
            array[counter] = currentNode.Value;
            currentNode = currentNode.NextNode;
            counter++;
        }

        return array.Reverse().ToArray();
    }

    private class QueueNode<T>
    {
        public QueueNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public QueueNode<T> NextNode { get; set; }

        public QueueNode<T> PrevNode { get; set; }
    }
}

