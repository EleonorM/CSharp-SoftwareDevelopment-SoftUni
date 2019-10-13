namespace BoxOfT
{
    using System;
    using System.Collections.Generic;
    public class Box<T>
    {
        private static Stack<T> elements = new Stack<T>();

        private int count = 0;

        public int Count { get { return this.count; } }


        public void Add(T element)
        {
            elements.Push(element);
            count++;
        }

        public T Remove()
        {
            if (count == 0)
            {
                throw new Exception();
            }

            var first = elements.Peek();
            elements.Pop();
            count--;
            return first;
        }
    }
}
