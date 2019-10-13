using System;

public class LinkedStack<T>
{
    private Node<T> firstNode;

    public int Count { get; private set; }

    public void Push(T element)
    {
        this.firstNode = new Node<T>(element, this.firstNode);
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var nodeToReturn = this.firstNode;
        this.firstNode = this.firstNode.NextNode;
        this.Count--;
        return nodeToReturn.Value;
    }

    public T[] ToArray()
    {
        var array = new T[this.Count];

        var currentNode = this.firstNode;
        var counter = 0;
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
        private T value;

        public T Value { get => this.value; set => this.value = value; }

        public Node<T> NextNode { get; set; }

        public Node(T value, Node<T> nextNode = null)
        {
            this.value = value;
            this.NextNode = nextNode;
        }
    }
}