namespace BillsPaymentSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BankAccount
    {
        [Key]
        public int BankAccountId { get; set; }

        public decimal Balance { get; set; }

        [MaxLength(50)]
        public string BankName { get; set; }

        [MaxLength(20)]
        public string SWIFT { get; set; }
        //o BankName(up to 50 characters, unicode)
    }
}
