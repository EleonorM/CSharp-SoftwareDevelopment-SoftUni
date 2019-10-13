namespace _07._SoftUni_Party
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            HashSet<string> guestList = new HashSet<string>();
            HashSet<string> vipGuestList = new HashSet<string>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "PARTY")
                {
                    break;
                }
                if (input[0] <= '9')
                {
                    vipGuestList.Add(input);
                }
                else
                    guestList.Add(input);
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                if (input[0] <= '9')
                {
                    vipGuestList.Remove(input);
                }
                else
                    guestList.Remove(input);
            }

            Console.WriteLine(guestList.Count + vipGuestList.Count);

            foreach (var guest in vipGuestList)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in guestList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
