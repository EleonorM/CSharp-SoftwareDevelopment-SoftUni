namespace _11._MathOperations
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            var action = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine(CalculateOperation(firstNumber, action, secondNumber));
        }

        static int CalculateOperation(int firstNumber, string mathOperator, int secondNumber)
        {
            if (mathOperator == "*")
            {
                return firstNumber * secondNumber;
            }
            else if (mathOperator == "+")
            {
                return firstNumber + secondNumber;
            }
            else if (mathOperator == "/")
            {
                return firstNumber / secondNumber;
            }
            else if (mathOperator == "-")
            {
                return firstNumber - secondNumber;
            }
            else
                return 0;
        }
    }
}
