namespace _08._MathPower
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine(CalculateMathPower(number, power));
        }

        static double CalculateMathPower(double number, int power)
        {
            double powerNum = 1;
            for (int i = 0; i < power; i++)
            {
                powerNum *= number;
            }

            return powerNum;
        }
    }
}
