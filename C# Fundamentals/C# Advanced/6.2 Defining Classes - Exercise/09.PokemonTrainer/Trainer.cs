namespace _09.PokemonTrainer
{
    using System.Collections.Generic;

    public class Trainer
    {
        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> CollectionOfPockemons { get; set; }

        public Trainer()
        {
            CollectionOfPockemons = new List<Pokemon>();
        }
    }
}
