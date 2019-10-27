namespace BillsPaymentSystem.Models
{
    using BillsPaymentSystem.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }

        public PaymentType Type { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public int? BankAccountId { get; set; }

        [ForeignKey(nameof(BankAccountId))]
        public BankAccount BankAccount { get; set; }

        public int? CreditCardId { get; set; }

        [ForeignKey(nameof(CreditCardId))]
        public CreditCard CreditCard { get; set; }
    }
}
