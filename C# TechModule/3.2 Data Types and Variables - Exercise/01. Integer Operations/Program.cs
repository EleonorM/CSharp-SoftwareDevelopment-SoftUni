namespace _01._Integer_Operations
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int forthNumber = int.Parse(Console.ReadLine());
            long sum = firstNumber + secondNumber;
            long devision = sum / thirdNumber;
            long multiplication = devision * forthNumber;
            Console.WriteLine(multiplication);
        }
    }
}
