namespace _01._Train
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int allPeople = int.Parse(Console.ReadLine());
            var peopleInVagon = new int[allPeople];
            var sum = 0;
            for (int i = 0; i < allPeople; i++)
            {
                var peopleGettingIn = int.Parse(Console.ReadLine());
                peopleInVagon[i] = peopleGettingIn;
                sum += peopleGettingIn;
            }

            for (int i = 0; i < peopleInVagon.Length; i++)
            {
                Console.Write($"{peopleInVagon[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
