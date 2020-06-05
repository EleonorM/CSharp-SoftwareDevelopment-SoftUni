namespace _03.ImplementArray_BasedStack
{
    using System;

    public class ArrayStack<T>
    {
        private T[] elements;

        private const int InitialCapacity = 16;

        public int Count { get; private set; }

        public ArrayStack(int capacity = InitialCapacity)
        {
            elements = new T[capacity];
        }

        public void Push(T element)
        {
            if (this.elements.Length == this.Count)
            {
                this.Grow();
            }

            elements[Count] = element;
            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var element = elements[Count - 1];
            elements[this.Count - 1] = default(T);
            Count--;
            return element;
        }

        public T[] ToArray()
        {
            var array = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                array[i] = elements[Count - 1 - i];
            }
            return array;
        }

        private void Grow()
        {
            var newArr = new T[Count * 2];
            Array.Copy(elements, newArr, Count);
            elements = newArr;
        }
    }
}
