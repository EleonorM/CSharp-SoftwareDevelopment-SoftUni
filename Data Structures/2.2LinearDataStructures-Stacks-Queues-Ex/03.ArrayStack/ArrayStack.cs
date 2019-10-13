using System;
using System.Linq;

public class ArrayStack<T>
{
    private const int InitialCapacity = 16;
    private T[] elements;

    public int Count { get; private set; }

    public ArrayStack(int capacity = InitialCapacity)
    {
        elements = new T[capacity];
    }

    public void Push(T element)
    {
        if (this.Count == this.elements.Length)
        {
            this.Grow();
        }
        elements[this.Count] = element;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        this.Count--;
        return this.elements[this.Count];
    }

    public T[] ToArray()
    {
        var newArray = new T[this.Count];
        Array.Copy(this.elements, newArray, this.Count);
        return newArray.Reverse().ToArray();
    }

    private void Grow()
    {
        var newArray = new T[2 * this.elements.Length];
        Array.Copy(this.elements, newArray, this.Count);
        elements = newArray;
    }
}
