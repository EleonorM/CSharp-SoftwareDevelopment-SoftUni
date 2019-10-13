namespace _3.Recursive_Drawing
{
    using System;

    public class Program
    {
        public static void Print(int index)
        {
            if (index == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', index));

            Print(index - 1);

            Console.WriteLine(new string('#', index));

            //return;
        }
        public static void Main()
        {
            var index = int.Parse(Console.ReadLine());
            Print(index);
        }
    }
}
