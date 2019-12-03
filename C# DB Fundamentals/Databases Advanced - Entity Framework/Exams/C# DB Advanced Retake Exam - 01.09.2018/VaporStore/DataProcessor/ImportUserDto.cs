namespace VaporStore.DataProcessor
{
    using System.ComponentModel.DataAnnotations;

    public class ImportUserDto
    {
        [Required]
        [RegularExpression("[A-Z][a-z]+ [A-Z][a-z]+")]
        public string FullName { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public CardDto[] Cards { get; set; }

        //      "FullName": "Lorrie Silbert",
        //"Username": "lsilbert",
        //"Email": "lsilbert@yahoo.com",
        //"Age": 33,
        //"Cards": [
        //	{
        //		"Number": "1833 5024 0553 6211",
        //		"CVC": "903",
        //		"Type": "Debit"

        //          },
        //	{
        //		"Number": "5625 0434 5999 6254",
        //		"CVC": "570",
        //		"Type": "Credit"
        //	},
        //	{
        //		"Number": "4902 6975 5076 5316",
        //		"CVC": "091",
        //		"Type": "Debit"
        //	}
        //]
    }

    public class CardDto
    {
        [Required]
        [RegularExpression(@"[\d]{4} [\d]{4} [\d]{4} [\d]{4}")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"[\d]{3}")]
        public int Cvc { get; set; }

        public string Type { get; set; }
    }
}
