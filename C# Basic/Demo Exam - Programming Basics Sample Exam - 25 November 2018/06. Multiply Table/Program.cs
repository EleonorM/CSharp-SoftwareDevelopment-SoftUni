namespace _06.Multiply_Table
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var firstNum = number % 10;
            var secondNum = number / 10 % 10;
            var thirdNum = number / 100;

            for (int first = 1; first <= firstNum; first++)
            {
                for (int second = 1; second <= secondNum; second++)
                {
                    for (int third = 1; third <= thirdNum; third++)
                    {
                        Console.WriteLine($"{first} * {second} * {third} = {first * second * third};");
                    }
                }
            }
        }
    }
}
