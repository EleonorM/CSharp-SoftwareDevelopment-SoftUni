namespace _1.Logger.Models.Contracts
{
    using _1.Logger.Models.Enumerations;
    using System;

    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}
