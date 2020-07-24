namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; } = new List<T>();

        public int Count => this.Items.Count;

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int InterpolationSearch(T item)
        {
            if (Count == 0)
            {
                return -1;
            }
            return BinarySearchProcedure(item, 0, Count - 1);
        }

        private int BinarySearchProcedure(T item, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
            {
                return -1;
            }

            int midpoint = startIndex + ((endIndex - startIndex) / 2);

            if (Items[midpoint].CompareTo(item) > 0)
            {
                return BinarySearchProcedure(item, startIndex, midpoint - 1);
            }

            if (Items[midpoint].CompareTo(item) < 0)
            {
                return BinarySearchProcedure(item, midpoint + 1, endIndex);
            }

            return midpoint;
        }

        public int InterpolationSearch(int searchValue)
        {
            if (Items.Count == 0)
            {
                return -1;
            }

            Type listType = typeof(T);
            if (listType != typeof(int))
            {
                throw new ArgumentException();
            }
            var collection = new List<int>();
            collection.AddRange((IEnumerable<int>)Items);
            return InterpolationSearchProcedure(collection, searchValue);
        }

        private int InterpolationSearchProcedure(List<int> collection, int item)
        {
            var low = 0;
            var high = Count - 1;

            while (collection[low].CompareTo(item) <= 0 && collection[high].CompareTo(item) >= 0)
            {
                int mid = low + ((item - collection[low]) * (high - low)) / (collection[high] - collection[low]);

                if (collection[mid].CompareTo(item) < 0)
                {
                    low = mid + 1;
                }
                else if (collection[mid].CompareTo(item) > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (collection[low].Equals(item))
            {
                return low;
            }
            else
            {
                return -1;
            }

        }

        public void Shuffle()
        {
            Shuffle(Items.Count - 1);
        }

        private void Shuffle(int index)
        {
            if (index == 0)
            {
                return;
            }
            var random = new Random();
            var randomIndex = random.Next(0, index);

            var element = Items[randomIndex];
            Items[randomIndex] = Items[index];
            Items[index] = element;

            Shuffle(index - 1);
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Items)}]";
        }
    }
}