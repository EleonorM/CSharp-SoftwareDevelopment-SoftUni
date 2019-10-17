namespace _6._Valid_Person
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Person pesho = new Person("Pesho", "Peshev", 24);
            try
            {
                Person noName = new Person(string.Empty, "Goshev", 31);

            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.Message}");
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine($"Exception thrown: {aore.Message}");
            }

            try
            {
                Person noLastName = new Person("Ivan", null, 63);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.Message}");
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine($"Exception thrown: {aore.Message}");
            }

            try
            {
                Person negativeAge = new Person("Stoyan", "Kolev", -1);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.Message}");
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine($"Exception thrown: {aore.Message}");
            }

            try
            {
                Person tooOldForThisProgram = new Person("Iskren", "Ivanov", 121);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.Message}");
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine($"Exception thrown: {aore.Message}");
            }
        }
    }
}
