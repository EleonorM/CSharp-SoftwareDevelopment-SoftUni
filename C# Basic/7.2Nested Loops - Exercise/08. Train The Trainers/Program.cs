namespace _08.Train_The_Trainers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var people = int.Parse(Console.ReadLine());
            var assigment = Console.ReadLine();
            var sumAll = 0.0;
            var counter = 0;
            while (assigment != "Finish")
            {
                var sum = 0.0;
                for (int i = 0; i < people; i++)
                {
                    var degree = double.Parse(Console.ReadLine());
                    sum += degree;
                }
                sumAll += sum / people;
                counter++;
                Console.WriteLine($"{assigment} - {sum / people:f2}.");
                assigment = Console.ReadLine();
            }

            Console.WriteLine($"Student's final assessment is {sumAll / counter:f2}.");
        }
    }
}
