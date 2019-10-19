namespace _10._LadyBugs
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int massiveLenght = int.Parse(Console.ReadLine().Trim());
            var ladyBugs = new int[massiveLenght];
            var positions = Console.ReadLine().Trim()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < positions.Length; i++)
            {
                int number = positions[i];
                if (number <= massiveLenght - 1 && number >= 0)
                {
                    ladyBugs[number] = 1;
                }
            }

            while (true)
            {
                var input = Console.ReadLine().Trim();
                if (input == "end")
                {
                    break;
                }
                var command = input.Split();
                int bugIndex = int.Parse(command[0]);
                var direction = command[1].ToLower();
                int flightLenght = int.Parse(command[2]);
                int counter = bugIndex;
                direction = FlightDirectionCorrection(direction, flightLenght);
                flightLenght = Math.Abs(flightLenght);

                if (bugIndex >= 0 && bugIndex < massiveLenght && ladyBugs[bugIndex] == 1)
                {
                    if (direction == "right")
                    {
                        while (true)
                        {
                            if (flightLenght == 0)
                            {
                                break;
                            }
                            else if (counter == ladyBugs.Length - 1 || counter + flightLenght > ladyBugs.Length - 1)
                            {
                                ladyBugs[bugIndex] = 0;
                                break;
                            }
                            else if (ladyBugs.Length > (counter + flightLenght) && ladyBugs[counter + flightLenght] == 0)
                            {
                                ladyBugs[counter + flightLenght] = 1;
                                ladyBugs[bugIndex] = 0;
                                break;
                            }
                            else
                                counter = counter + flightLenght;
                        }
                    }
                    else if (direction == "left")
                    {
                        while (true)
                        {
                            if (flightLenght == 0)
                            {
                                break;
                            }
                            else if (counter == 0 || flightLenght > bugIndex || counter - flightLenght < 0)
                            {
                                ladyBugs[bugIndex] = 0;
                                break;
                            }
                            else if (0 <= (counter - flightLenght) && ladyBugs[counter - flightLenght] == 0)
                            {
                                ladyBugs[counter - flightLenght] = 1;
                                ladyBugs[bugIndex] = 0;
                                break;
                            }
                            else
                                counter = counter - flightLenght;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", ladyBugs));
        }

        static string FlightDirectionCorrection(string flightDirection, int flightLength)
        {
            if (flightLength < 0)
            {
                switch (flightDirection)
                {
                    case "left": flightDirection = "right"; break;
                    case "right": flightDirection = "left"; break;
                }
            }
            return flightDirection;
        }
    }
}
