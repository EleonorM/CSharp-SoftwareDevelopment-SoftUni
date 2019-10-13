namespace _1.Logger.Models.Contracts
{
    using System.Collections.Generic;

    public interface ILogger
    {
        IReadOnlyCollection<IAppender> ConsoleAppender { get; }

        void Log(IError error);
    }
}