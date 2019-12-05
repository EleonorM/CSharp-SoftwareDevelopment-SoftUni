namespace Cinema.Data.Models
{
    using Enums;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;

    public class Movie
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string Title { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [Range(1,10)]
        public double Rating { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string Director { get; set; }

        public ICollection<Projection> Projections { get; set; } = new HashSet<Projection>();
    }
}
