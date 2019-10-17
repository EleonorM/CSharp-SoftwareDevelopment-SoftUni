namespace Workshop_Create_Linked_List
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {

            var list = new DoublyLinkedList();

            list.AddFirst(5);
            list.AddLast(7);
            list.AddFirst(8);
            list.RemoveLast();
            list.ForEach(n => Console.WriteLine(n));
            var array = list.ToArray();
            Console.WriteLine(list.Count);
        }
    }
}
