namespace _06.ImplementTheDataStructure
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var arr = new ReversedList<int>();

            arr.Add(1);
            arr.Add(2);
            arr.Add(3);

            arr[0] = 4;
            arr.Remove(0);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
