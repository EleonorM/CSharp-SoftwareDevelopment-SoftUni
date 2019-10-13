namespace _1.Logger.Models.Contracts
{
    public interface IFile
    {
        string Path { get; }

        ulong Size { get; }

        string Write(ILayout layout, IError error);
    }
}
