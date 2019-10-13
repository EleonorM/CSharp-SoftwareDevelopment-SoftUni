
using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IReversedList<T>, IEnumerable<T>
{
    private T[] array;

    public ReversedList()
    {
        array = new T[2];
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return this.array[this.Count - index - 1];
        }

        set
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.array[this.Count - index - 1] = value;
        }
    }

    public int Count { get; private set; }

    public int Capacity => this.array.Length;

    public void Add(T item)
    {
        if (this.Count == this.Capacity)
        {
            this.Grow();
        }
        array[this.Count] = item;
        this.Count++;
    }

    private void Grow()
    {
        var newArray = new T[this.Count * 2];
        Array.Copy(this.array, newArray, this.Count);
        array = newArray;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return array[i];
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        //for (int i = this.Count - 1; i >= index; i--)
        //{
        //    this.array[i] = this.array[i + 1];
        //}
        for (int i = this.Count - index - 1; i < this.Count; i++)
        {
            this.array[i] = this.array[i + 1];
        }
        this.Count--;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
