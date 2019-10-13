namespace _03.Stack
{
    using System.Collections;
    using System.Collections.Generic;

    class MyStack<T> : IEnumerable<T>
    {
        public MyStack()
        {
            Stack = new List<T>();
        }

        public List<T> Stack { get; set; }

        public void Push(T item)
        {
            this.Stack.Insert(0, item);
        }

        public void Pop()
        {
            if (Stack.Count != 0)
            {
                var element = this.Stack[0];
                this.Stack.RemoveAt(0);
            }
            else
            {
                System.Console.WriteLine("No elements");
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.Stack)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
