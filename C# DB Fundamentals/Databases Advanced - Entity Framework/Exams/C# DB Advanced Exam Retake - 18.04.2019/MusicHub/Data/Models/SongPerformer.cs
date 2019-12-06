namespace MusicHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SongsPerformers")]
    public class SongPerformer
    {
        public int SongId { get; set; }

        [Required]
        public Song Song { get; set; }

        public int PerformerId { get; set; }

        [Required]
        public Performer Performer { get; set; }
    }
}
