namespace _1.Logger.Models.Contracts
{
    using _1.Logger.Models.Enumerations;

    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        void Append(IError error);
    }
}