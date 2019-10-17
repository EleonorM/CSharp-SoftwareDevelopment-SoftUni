namespace _09.CollectionHierarchy
{
    using System.Collections.Generic;
    public class MyList : IMyList
    {
        public MyList()
        {
            Collection = new List<string>();
            Collection.Capacity = 100;
        }

        public List<string> Collection { get; private set; }

        public int Used { get => this.Collection.Count; }

        public int Add(string item)
        {
            Collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            var objectToRemove = Collection[0];
            Collection.RemoveAt(0);
            return objectToRemove;
        }
    }
}
