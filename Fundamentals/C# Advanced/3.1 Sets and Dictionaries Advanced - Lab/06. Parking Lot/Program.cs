namespace _06._Parking_Lot
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            HashSet<string> plates = new HashSet<string>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                var line = input.Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
                var command = line[0];
                var carNumber = line[1];
                if (command == "IN")
                {
                    plates.Add(carNumber);
                }
                else if (command == "OUT")
                {
                    plates.Remove(carNumber);
                }
            }

            if (plates.Count > 0)
            {
                foreach (var num in plates)
                {
                    Console.WriteLine(num);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
