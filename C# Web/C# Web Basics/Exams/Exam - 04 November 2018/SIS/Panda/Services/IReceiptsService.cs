namespace Panda.Services
{
    using Panda.ViewModels.Receipts;

    public interface IReceiptsService
    {
        ReceiptsIndexOutputModel GetReceipts();
    }
}
