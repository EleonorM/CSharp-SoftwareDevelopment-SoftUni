namespace _09._Spice_Must_Flow
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int staritngYield = int.Parse(Console.ReadLine());

            int spiceLeft = 0;
            int yieldDrop = staritngYield;
            int counter = 0;
            while (true)
            {


                if (yieldDrop < 100)
                {
                    if (spiceLeft > 26)
                    {
                        spiceLeft -= 26;
                    }
                    else
                    {
                        spiceLeft = 0;
                    }

                    break;
                }
                spiceLeft += yieldDrop - 26;
                counter++;
                yieldDrop -= 10;
            }

            Console.WriteLine(counter);
            Console.WriteLine(spiceLeft);
        }
    }
}
