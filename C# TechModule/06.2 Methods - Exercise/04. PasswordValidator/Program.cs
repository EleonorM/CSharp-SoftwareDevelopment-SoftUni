namespace _04._PasswordValidator
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            if (IsLongEnough(input) && ContainsOnlyLettersAndDigits(input) && ContainsAtLeast2Digits(input))
            {
                Console.WriteLine("Password is valid");
            }

            if (!IsLongEnough(input))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!ContainsOnlyLettersAndDigits(input))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!ContainsAtLeast2Digits(input))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }

        static bool IsLongEnough(string password)
        {
            var passwordChar = password.ToCharArray();
            if (passwordChar.Length >= 6 && passwordChar.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool ContainsOnlyLettersAndDigits(string password)
        {
            var passwordChar = password.ToCharArray();
            for (int i = 0; i < passwordChar.Length; i++)
            {
                if (passwordChar[i] >= '0' && passwordChar[i] <= '9' ||
                    passwordChar[i] >= 'A' && passwordChar[i] <= 'Z' ||
                    passwordChar[i] >= 'a' && passwordChar[i] <= 'z')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        static bool ContainsAtLeast2Digits(string password)
        {
            var passwordChar = password.ToCharArray();
            int counter = 0;
            for (int i = 0; i < passwordChar.Length; i++)
            {
                if (passwordChar[i] >= '0' && passwordChar[i] <= '9')
                {
                    counter++;
                }
            }

            if (counter >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
