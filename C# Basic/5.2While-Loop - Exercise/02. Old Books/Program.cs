namespace _02.Old_Books
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var seachedBook = Console.ReadLine();
            var numberBooks = int.Parse(Console.ReadLine());
            var count = 0;

            for (int i = 0; i < numberBooks; i++)
            {
                var book = Console.ReadLine();
                if (book == seachedBook)
                {
                    Console.WriteLine($"You checked {count} books and found it.");
                    return;
                }
                count++;
            }

            Console.WriteLine("The book you search is not here!");
            Console.WriteLine($"You checked {count} books.");
        }
    }
}
