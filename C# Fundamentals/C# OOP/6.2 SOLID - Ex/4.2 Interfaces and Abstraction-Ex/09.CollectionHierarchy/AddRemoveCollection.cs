namespace _09.CollectionHierarchy
{
    using System.Collections.Generic;
    public class AddRemoveCollection : IAddRemoveCollection
    {
        public AddRemoveCollection()
        {
            Collection = new List<string>();
            Collection.Capacity = 100;
        }

        public List<string> Collection { get; private set; }

        public int Add(string item)
        {
            Collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            var objectToRemove = Collection[Collection.Count - 1];
            Collection.RemoveAt(Collection.Count - 1);
            return objectToRemove;
        }
    }
}
