namespace _03._Calculations
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var action = Console.ReadLine();
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            switch (action)
            {
                case "add":
                    AddNumbers(firstNumber, secondNumber);
                    break;
                case "multiply":
                    MultiplyNumbers(firstNumber, secondNumber);
                    break;
                case "subtract":
                    SubtractNumbers(firstNumber, secondNumber);
                    break;
                case "divide":
                    DivideNumbers(firstNumber, secondNumber);
                    break;
            }
        }

        static void AddNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber + secondNumber);
        }

        static void MultiplyNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber * secondNumber);
        }

        static void SubtractNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber - secondNumber);
        }

        static void DivideNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber / secondNumber);
        }
    }
}
