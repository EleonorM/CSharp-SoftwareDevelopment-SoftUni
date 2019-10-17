namespace _08.MilitaryElite.Exceptions
{
    using System;

    public class InvalidCorseException : Exception
    {
        private const string EXC_MESSAGE = "Invalid corpse!";

        public InvalidCorseException():base(EXC_MESSAGE)
        {
        }

        public InvalidCorseException(string message) : base(message)
        {
        }
    }
}
