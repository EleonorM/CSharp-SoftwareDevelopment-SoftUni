namespace MusicHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Performer
    {
        public int Id { get; set; }


        [Required]
        [MaxLength(20), MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string LastName { get; set; }

        [Range(18, 70)]
        public int Age { get; set; }

        [Required]
        [Range(0, (double)decimal.MaxValue)]
        public decimal NetWorth { get; set; }

        public ICollection<SongPerformer> PerformerSongs { get; set; } = new HashSet<SongPerformer>();
    }
}
