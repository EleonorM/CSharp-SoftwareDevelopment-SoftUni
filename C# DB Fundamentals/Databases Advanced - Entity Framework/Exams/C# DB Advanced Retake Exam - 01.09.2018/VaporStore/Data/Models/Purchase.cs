namespace VaporStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Purchase
    {
        public int Id { get; set; }

        [Required]
        public PurchaseType Type { get; set; }

        [Required]
        [RegularExpression(@"[A-Z|\d]{4}-[A-Z|\d]{4}-[A-Z|\d]{4}")]
        public int ProductKey { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int CardId { get; set; }

        [Required]
        public Card Card { get; set; }

        public int GameId { get; set; }

        [Required]
        public Game Game { get; set; }
    }
}
