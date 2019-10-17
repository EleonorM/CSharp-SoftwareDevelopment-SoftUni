namespace _04.GenericSwapMethodInteger
{
    using System.Collections.Generic;

    public static class ListExtensions
    {
        public static List<T> Swap<T>(this List<T> collection, int index1, int index2)
        {
            if (index1 < index2)
            {
                var elementToInsert = collection[index1];
                var elementToInsert2 = collection[index2];
                collection.RemoveAt(index1);
                collection.RemoveAt(index2 - 1);
                collection.Insert(index2 - 1, elementToInsert);
                collection.Insert(index1, elementToInsert2);
                return collection;
            }
            else if (index1 > index2)
            {
                var elementToInsert = collection[index1];
                var elementToInsert2 = collection[index2];
                collection.RemoveAt(index1);
                collection.RemoveAt(index2);
                collection.Insert(index2, elementToInsert);
                collection.Insert(index1, elementToInsert2);
                return collection;
            }
            else
            {
                return collection;
            }
        }
    }
}
