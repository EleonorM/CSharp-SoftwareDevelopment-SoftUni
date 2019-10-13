namespace _5._Convert.ToDouble
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var lineToConver = Console.ReadLine();
            try
            {
                var result = Convert.ToDouble(lineToConver);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
        }
    }
}
