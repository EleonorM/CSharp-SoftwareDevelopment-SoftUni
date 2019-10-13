namespace _02.Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
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

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var cuurentItem in this.Collection)
            {
                yield return cuurentItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void PrintAll()
        {
            if (Collection.Count != 0)
            {
                foreach (var item in Collection)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            else
            {
                throw new System.ArgumentNullException("The list is empty!");
            }
        }
    }
}
