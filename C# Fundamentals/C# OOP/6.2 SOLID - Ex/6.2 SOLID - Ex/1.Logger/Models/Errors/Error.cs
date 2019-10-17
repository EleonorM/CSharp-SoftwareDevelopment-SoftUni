namespace _1.Logger.Models.Errors
{
    using _1.Logger.Models.Contracts;
    using _1.Logger.Models.Enumerations;
    using System;

    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level = Level.INFO)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }
    }
}
