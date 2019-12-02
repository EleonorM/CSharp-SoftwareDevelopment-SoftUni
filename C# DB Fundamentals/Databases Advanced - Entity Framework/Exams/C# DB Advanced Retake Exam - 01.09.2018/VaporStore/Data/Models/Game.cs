namespace VaporStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public int DeveloperId { get; set; }

        [Required]
        public Developer Developer { get; set; }

        public int GenreId { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();

        [MinLength(1)]
        public ICollection<GameTag> GameTags { get; set; } = new HashSet<GameTag>();

        //•	GameTags - collection of type GameTag.Each game must have at least one tag.


    }
}
