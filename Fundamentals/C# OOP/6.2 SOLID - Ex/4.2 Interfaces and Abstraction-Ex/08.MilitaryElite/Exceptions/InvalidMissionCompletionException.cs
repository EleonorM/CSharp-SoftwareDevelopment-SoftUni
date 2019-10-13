namespace _08.MilitaryElite.Exceptions
{
    using System;

    public class InvalidMissionCompletionException : Exception
    {
        private const string EXC_MESSAGE = "Already compleated mission!";

        public InvalidMissionCompletionException() : base(EXC_MESSAGE)
        {
        }

        public InvalidMissionCompletionException(string message) : base(message)
        {
        }
    }
}
