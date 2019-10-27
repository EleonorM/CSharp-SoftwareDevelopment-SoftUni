namespace BillsPaymentSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(80)]
        public string Email { get; set; }

        [MaxLength(25)]
        public string Password { get; set; }
        //o FirstName(up to 50 characters, unicode)
        //o LastName(up to 50 characters, unicode)
    }
}
