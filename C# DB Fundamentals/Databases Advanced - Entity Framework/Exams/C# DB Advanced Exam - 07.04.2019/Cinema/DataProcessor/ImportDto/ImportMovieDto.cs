namespace Cinema.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public  class ImportMovieDto
    {
        [Required]
        [MaxLength(20), MinLength(3)]
        public string Title { get; set; }

        [Required]
        public string  Genre { get; set; }
        
        [Required]
        public string Duration { get; set; }

        [Required]
        [Range(1, 10)]
        public double Rating { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string Director { get; set; }
    }
}
