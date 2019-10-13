namespace _09.CollectionHierarchy
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            AddToCollection(addCollection, input);
            AddToCollection(addRemoveCollection, input);
            AddToCollection(myList, input);

            var removeInput = int.Parse(Console.ReadLine());

            RemoveFromCollection(addRemoveCollection, removeInput);
            RemoveFromCollection(myList, removeInput);
        }

        private static void RemoveFromCollection(IAddRemoveCollection addRemoveCollection, int removeInput)
        {
            for (int i = 0; i < removeInput; i++)
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }
            Console.WriteLine();
        }

        private static void AddToCollection(IAddCollection addCollection, string[] input)
        {
            foreach (var item in input)
            {
                Console.Write(addCollection.Add(item) + " ");
            }
            Console.WriteLine();
        }
    }
}
