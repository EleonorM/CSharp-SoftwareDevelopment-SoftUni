﻿namespace _07.On_Time_for_the_Exam
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var examHour = int.Parse(Console.ReadLine());
            var examMinutes = int.Parse(Console.ReadLine());
            var arrivalHour = int.Parse(Console.ReadLine());
            var arrivalMinutes = int.Parse(Console.ReadLine());

            string late = "Late";
            string onTime = "On time";
            string early = "Early";

            int examTime = examHour * 60 + examMinutes;
            int arrivalTime = arrivalHour * 60 + arrivalMinutes;

            int totalMinutesDifference = arrivalTime - examTime;

            string studentArrival = late;
            if (totalMinutesDifference < -30)
                studentArrival = early;
            else if (totalMinutesDifference >= -30 && totalMinutesDifference <= 0)
                studentArrival = onTime;

            string result = string.Empty;
            if (totalMinutesDifference != 0)
            {
                int hoursDifference = Math.Abs(totalMinutesDifference / 60);
                int minutesDifference = Math.Abs(totalMinutesDifference % 60);

                if (hoursDifference > 0)
                {
                    result = string.Format("{0}:{1:00} hours", hoursDifference, minutesDifference);
                }
                else
                {
                    result = minutesDifference + "minutes";
                }
                if (totalMinutesDifference < 0)
                {
                    result += " before the start";
                }
                else
                {
                    result += " after the start";
                }

            }

            Console.WriteLine(studentArrival);

            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
            }
        }
    }
}
