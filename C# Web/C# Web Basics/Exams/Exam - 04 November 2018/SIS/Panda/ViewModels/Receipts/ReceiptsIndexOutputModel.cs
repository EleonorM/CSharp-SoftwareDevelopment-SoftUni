namespace Panda.ViewModels.Receipts
{
    using System.Collections.Generic;

    public class ReceiptsIndexOutputModel
    {
        public ICollection<ReceiptModel> Receipts { get; set; } = new HashSet<ReceiptModel>();
    }
}
