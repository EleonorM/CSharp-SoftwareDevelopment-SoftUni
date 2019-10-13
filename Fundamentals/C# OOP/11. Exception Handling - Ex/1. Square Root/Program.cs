namespace _1._Square_Root
{
    using System;

    public class Program
    {
        public static void Main()
        {
            try
            {
                var number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArgumentException();
                }
                Console.WriteLine(Math.Sqrt(number));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
