namespace _4.FixingVol2
{
    using System;

    public class Program
    {
        public static void Main()
        {
            try
            {
                int num1, num2;
                byte result;

                num1 = 30;
                num2 = 60;
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine($"{num1} x {num2} = {result}");
                Console.ReadLine();

            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
        }
    }
}
