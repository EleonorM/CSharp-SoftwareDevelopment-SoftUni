namespace _11._Snowballs
{
    using System;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            int numberSnowballs = int.Parse(Console.ReadLine());
            BigInteger higestSnowballValue = 0;
            int higestSnowballSnow = 0;
            int higestSnowballTime = 0;
            int higestSnowballQuality = -1;
            for (int i = 0; i < numberSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                BigInteger snowballValue = 1;
                for (int j = 0; j < snowballQuality; j++)
                {
                    snowballValue *= (snowballSnow / snowballTime);
                }
                if (snowballValue > higestSnowballValue)
                {
                    higestSnowballValue = snowballValue;
                    higestSnowballQuality = snowballQuality;
                    higestSnowballSnow = snowballSnow;
                    higestSnowballTime = snowballTime;
                }
            }

            Console.WriteLine($"{higestSnowballSnow} : {higestSnowballTime} = {higestSnowballValue} ({higestSnowballQuality})");
        }
    }
}
