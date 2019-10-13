namespace _7._Custom_Exception
{
    using System;

    public class Program
    {
        public static void Main()
        {
            try
            {
                var student = new Student("Gen4o", "gencho@gmail.com");
            }
            catch (InvalidPersonNameException ipne)
            {
                Console.WriteLine(ipne.Message);
            }
        }
    }
}
