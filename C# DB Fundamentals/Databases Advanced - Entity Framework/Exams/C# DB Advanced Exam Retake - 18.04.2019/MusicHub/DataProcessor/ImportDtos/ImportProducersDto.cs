namespace MusicHub.DataProcessor.ImportDtos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ImportProducersDto
    {
        [Required]
        [MaxLength(30), MinLength(3)]
        public string Name { get; set; }

        [RegularExpression(@"[A-Z][\w]+ [A-Z][\w]+")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"\+359 \d{3} \d{3} \d{3}")]
        public string PhoneNumber { get; set; }

        public ImportAlbumDto[] Albums { get; set; }
    }

    public class ImportAlbumDto
    {
        [Required]
        [MaxLength(40), MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }
    }
}
