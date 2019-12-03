namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
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
            var userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);
            var sb = new StringBuilder();
            var users = new List<User>();
            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }


                var user = new User
                {
                    FullName = userDto.FullName,
                    Age = userDto.Age,
                    Email = userDto.Email,
                    Username = userDto.Username,
                    Cards = userDto.Cards.Select(x => new Card
                    {
                        Cvc = x.Cvc.ToString(),
                        Type = Enum.Parse<CardType>(x.Type),
                        Number = x.Number
                    })
                    .ToArray()
                };

                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));

            var purchaseDtos = (ImportPurchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var purchases = new List<Purchase>();

            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (!Enum.TryParse<PurchaseType>(purchaseDto.Type, out PurchaseType purchaseType))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.CardNumber);
                var game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.GameName);
                if (card == null || game == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = purchaseType,
                    ProductKey = purchaseDto.Key,
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Game = game,
                    Card = card
                };

                purchases.Add(purchase);
                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
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