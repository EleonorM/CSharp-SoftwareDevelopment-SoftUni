namespace _09.CollectionHierarchy
{
    using System.Collections.Generic;
    public class AddCollection : IAddCollection
    {
        public AddCollection()
        {
            Collection = new List<string>();
            Collection.Capacity = 100;
        }

        public List<string> Collection { get; private set; }

        public int Add(string item)
        {
            Collection.Add(item);
            return Collection.Count - 1;
        }
    }
}
