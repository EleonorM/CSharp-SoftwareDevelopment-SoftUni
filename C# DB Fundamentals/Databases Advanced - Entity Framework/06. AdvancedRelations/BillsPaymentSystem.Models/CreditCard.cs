namespace BillsPaymentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CreditCard
    {
        [Key]
        public int CreditCardId { get; set; }

        public decimal Limit { get; set; }

        public decimal MoneyOwned { get; set; }

        //??
        [NotMapped]
        public decimal LimitLeft => MoneyOwned - Limit;

        public DateTime ExpirationDate { get; set; }
    }
}
