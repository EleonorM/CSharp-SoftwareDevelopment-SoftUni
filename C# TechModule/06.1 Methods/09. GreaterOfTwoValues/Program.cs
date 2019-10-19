namespace _09._GreaterOfTwoValues
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var type = Console.ReadLine();
            switch (type)
            {
                case "int":
                    int firstNum = int.Parse(Console.ReadLine());
                    int secondNum = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstNum, secondNum));
                    break;
                case "char":
                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstChar, secondChar));
                    break;
                case "string":
                    string firstString = Console.ReadLine();
                    string secondString = Console.ReadLine();
                    Console.WriteLine(GetMax(firstString, secondString));
                    break;
                default:
                    break;
            }
        }

        static int GetMax(int firstNumber, int secondNumber)
        {
            if (firstNumber > secondNumber)
            {
                return firstNumber;
            }
            else
                return secondNumber;
        }

        static char GetMax(char firstChar, char secondChar)
        {
            if (firstChar > secondChar)
            {
                return firstChar;
            }
            else
                return secondChar;
        }

        static string GetMax(string firstString, string secondString)
        {
            if (string.Compare(firstString, secondString) < 0)
            {
                return secondString;
            }
            else
                return firstString;
        }
    }
}
