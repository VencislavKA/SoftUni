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
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedGame
            = "Added {gameName} ({gameGenre}) with {tagsCount} tags";

        private const string SuccessfullyImportedUser
            = "Imported {username} with {cardsCount} cards";

        private const string SuccessfullyImportedPurchasses
            = "Imported {gameName} for {username}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            var gamesDTOs = JsonConvert.DeserializeObject<ImportGamesDTO[]>(jsonString);
            var games = new List<Game>();
            var developers = new List<Developer>();
            var genres = new List<Genre>();
            var tags = new List<Tag>();
            var sb = new StringBuilder();

            foreach (var dto in gamesDTOs)
            {
                Developer dev;
                Genre genre;
                int tagCounter = 0;

                if (!IsValid(dto) || dto.Tags.Length == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                dev = developers.FirstOrDefault(d => d.Name == dto.Developer);
                genre = genres.FirstOrDefault(g => g.Name == dto.Genre);

                var game = new Game()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    ReleaseDate = DateTime.ParseExact(dto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = dev == null ? new Developer() { Name = dto.Developer } : dev,
                    Genre = genre == null ? new Genre() { Name = dto.Genre } : genre
                };

                foreach (var tag in dto.Tags)
                {
                    GameTag searchTag;
                    if (tags.FirstOrDefault(t => t.Name == tag) == null)
                    {
                        var tagtoAdd = new Tag() { Name = tag };
                        game.GameTags.Add(new GameTag { Game = game, Tag = tagtoAdd });
                        tags.Add(tagtoAdd);
                    }
                    else
                    {
                        var foundTag = tags.FirstOrDefault(t => t.Name == tag);
                        game.GameTags.Add(new GameTag { Game = game, Tag = foundTag });
                    }
                    tagCounter++;
                }

                games.Add(game);
                if (dev == null)
                {
                    developers.Add(game.Developer);
                }
                if (genre == null)
                {
                    genres.Add(game.Genre);
                }

                sb.AppendLine(string.Format($"Added {game.Name} ({game.Genre.Name}) with {tagCounter} tags"));
            }

            context.Tags.AddRange(tags);
            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportUsersAndCardsJsonDto[] usersDtos = JsonConvert.DeserializeObject<ImportUsersAndCardsJsonDto[]>(jsonString);

            List<User> users = new List<User>();

            foreach (var userDto in usersDtos)
            {
                if (!IsValid(userDto))
                {
                    sb
                        .AppendLine("Invalid Data");
                    continue;
                }

                User user = new User()
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        sb
                            .AppendLine("Invalid Data");
                        continue;
                    }

                    Card card = new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = (CardType)cardDto.Type
                    };

                    user.Cards.Add(card);
                }

                users.Add(user);

                sb
                    .AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{

            var serializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));

            StringBuilder sb = new StringBuilder();


            using (StringReader sr = new StringReader(xmlString))
            {
                var purchasesDtos = (ImportPurchaseDto[])serializer.Deserialize(sr);

                List<Purchase> lists = new List<Purchase>();
                List<Purchase> purchases = lists;

                foreach (var purchaseDto in purchasesDtos)
                {
                    if (!IsValid(purchaseDto))
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    var card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card);

                    var game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title);

                    Purchase purchase = new Purchase
                    {
                        Type = Enum.Parse<PurchaseType>(purchaseDto.Type),
                        ProductKey = purchaseDto.ProductKey,
                        Card = card,
                        Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None),
                        Game = game
                    };

                    var username = context.Users.FirstOrDefault(x => x.Id == purchase.Card.UserId);

                    purchases.Add(purchase);

                    sb.AppendLine($"Imported {purchase.Game.Name} for {username.Username}");
                }

                context.Purchases.AddRange(purchases);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}