using System;
using System.Linq;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] user = input.ToCharArray();
            char[] password = new char[user.Length];
            for (int i = 0; i < user.Length; i++)
            {
                password[i] = user[user.Length - i-1];
            }
            int counter = 0;
            while (true)
            {
                char[] word = Console.ReadLine().ToCharArray();
                if (Enumerable.SequenceEqual(word, password))
                {
                    Console.WriteLine($"User {string.Join("",user)} logged in.");
                    return;
                }
                else
                {
                    counter++;
                    if (counter == 4)
                    {
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
                
            }
            Console.WriteLine($"User {string.Join("",user)} blocked!");

        }
    }
}
