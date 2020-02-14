namespace Panda.Services
{
    using Panda.ViewModels.Receipts;
    using System.Linq;

    public class ReceiptsService : IReceiptsService
    {
        private PandaDbContext db;

        public ReceiptsService(PandaDbContext db)
        {
            this.db = db;
        }

        public ReceiptsIndexOutputModel GetReceipts()
        {
            return new ReceiptsIndexOutputModel
            {
                Receipts = this.db.Receipts.Select(x => new ReceiptModel
                {
                    Id = x.Id,
                    Fee = x.Fee,
                    IssuedOn = x.IssuedOn.ToString("MM/dd/yyyy H:mm"),
                    RecipientName = x.Recipient.Username,
                }).ToList(),
            };
        }
    }
}
