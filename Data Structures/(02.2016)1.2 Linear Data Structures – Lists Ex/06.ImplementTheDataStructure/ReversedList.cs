namespace _06.ImplementTheDataStructure
{
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
                if (index < 0 || index > Count)
                {
                    throw new ArgumentException();
                }
                return this.array[Count - index - 1];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentException();
                }
                array[Count - index - 1] = value;
            }
        }

        public int Count { get; private set; }

        public int Capacity => this.array.Length;

        public void Add(T item)
        {
            if (Count == Capacity)
            {
                this.Grow();
            }
            array[Count] = item;
            Count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                throw new ArgumentException();
            }

            for (int i = Count - index - 1; i < Count; i++)
            {
                array[i] = array[i + 1];
            }
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Grow()
        {
            var newArray = new T[Capacity * 2];
            Array.Copy(array, newArray, Capacity);
            array = newArray;
        }
    }
}
