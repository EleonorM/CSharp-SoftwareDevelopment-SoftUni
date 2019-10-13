namespace _01.ListyIterator
{
    using System;
    using System.Collections.Generic;

    public class ListyIterator<T>
    {
        public ListyIterator()
        {
            Collection = new List<T>();
        }
        public ListyIterator(List<T> collection)
        {
            Collection = new List<T>(collection);
        }

        public int Index = 0;

        public List<T> Collection { get; private set; }

        public bool Move()
        {
            if (Collection.Count - 1 > Index)
            {
                Index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (Collection.Count - 1 > Index)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (Collection.Count > Index)
            {
                Console.WriteLine(Collection[Index]);
            }
            else
            {
                throw new System.InvalidOperationException("Invalid Operation!");
            }
        }
    }
}
