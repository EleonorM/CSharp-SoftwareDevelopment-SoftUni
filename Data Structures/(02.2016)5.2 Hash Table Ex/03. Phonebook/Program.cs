namespace _03._Phonebook
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var phonebook = new HashTable<string, string>();
            string input = Console.ReadLine();
            while (input != "search")
            {
                var inputArray = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = inputArray[0];
                var phone = inputArray[1];

                phonebook.Add(name, phone);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (true)
            {
                var contact = phonebook.Find(input);
                if (contact == null)
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }
                else
                {
                    Console.WriteLine($"{contact.Key} -> {contact.Value}");
                }

                input = Console.ReadLine();
            }
        }
    }
}
