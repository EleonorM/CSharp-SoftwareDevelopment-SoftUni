namespace _07.ImplementLinkedList
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>();

            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(3);

            list.Remove(2);

            foreach (var num in list)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine(list.FirstIndexOf(3));
            Console.WriteLine(list.LastIndexOf(3));
        }
    }
}
