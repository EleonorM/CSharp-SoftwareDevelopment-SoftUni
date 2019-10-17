using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
   public class Box<T>
    {
        public int Count {
            get
            {
                return this.Count;
            }

            set
            {
                this.Count = this.Elements.Count;
            }
        }

        public List<T> Elements { get; set; } = new List<T>();

        public void Add(T element)
        {
            this.Elements.Insert(0, element);
        }

        public T Remove()
        {
            if (this.Elements.Count == 0)
            {
                throw new ArgumentNullException("The list is empty.");
            }

            var first = this.Elements[0];
            this.Elements.RemoveAt(0);
            return first;
        }
    }
}
