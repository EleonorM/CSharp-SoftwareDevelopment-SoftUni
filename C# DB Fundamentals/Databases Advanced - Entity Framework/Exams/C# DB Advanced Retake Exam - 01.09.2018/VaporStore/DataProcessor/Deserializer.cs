namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);
            var sb = new StringBuilder();
            var games = new List<Game>();
            foreach (var gameDto in gameDtos)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var developer = GetDeveloper(context, gameDto);
                var genre = GetGenre(context, gameDto);

                var game = new Game
                {
                    Name = gameDto.Name,
                    Developer = developer,
                    Genre = genre,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                };

                foreach (var currentTag in gameDto.Tags)
                {
                    var tag = GetTag(context, currentTag);
                    game.GameTags.Add(new GameTag
                    {
                        Tag = tag,
                        Game = game
                    });
                }

                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
                games.Add(game);
            }

            context.Games.AddRange(games);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }
             

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);
            var sb = new StringBuilder();
            var games = new List<Game>();
            foreach (var gameDto in gameDtos)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var developer = GetDeveloper(context, gameDto);
                var genre = GetGenre(context, gameDto);

                var game = new Game
                {
                    Name = gameDto.Name,
                    Developer = developer,
                    Genre = genre,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                };

                foreach (var currentTag in gameDto.Tags)
                {
                    var tag = GetTag(context, currentTag);
                    game.GameTags.Add(new GameTag
                    {
                        Tag = tag,
                        Game = game
                    });
                }

                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
                games.Add(game);
            }

            context.Games.AddRange(games);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static Tag GetTag(VaporStoreDbContext context, string tag)
        {
            if (!context.Tags.Any(x => x.Name == tag))
            {
                var tagNew = new Tag { Name = tag };
                context.Tags.Add(tagNew);
            }

            context.SaveChanges();
            return context.Tags.First(x => x.Name == tag);
        }

        private static Genre GetGenre(VaporStoreDbContext context, ImportGameDto gameDto)
        {
            if (!context.Genres.Any(x => x.Name == gameDto.Genre))
            {
                var genre = new Genre { Name = gameDto.Genre };
                context.Genres.Add(genre);
            }

            context.SaveChanges();
            return context.Genres.First(x => x.Name == gameDto.Genre);
        }

        private static Developer GetDeveloper(VaporStoreDbContext context, ImportGameDto gameDto)
        {
            if (!context.Developers.Any(x => x.Name == gameDto.Developer))
            {
                var developer = new Developer { Name = gameDto.Developer };
                context.Developers.Add(developer);
            }
            context.SaveChanges();
            return context.Developers.First(x => x.Name == gameDto.Developer);
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}