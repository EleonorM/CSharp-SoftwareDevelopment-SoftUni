namespace MusicHub.DataProcessor
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
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writerDtos = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);
            var writers = new List<Writer>();
            var sb = new StringBuilder();
            foreach (var writerDto in writerDtos)
            {
                if (!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                writers.Add(writer);

                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producerDtos = JsonConvert.DeserializeObject<ImportProducersDto[]>(jsonString);
            var producers = new List<Producer>();
            var sb = new StringBuilder();
            foreach (var producerDto in producerDtos)
            {
                if (!IsValid(producerDto) || !producerDto.Albums.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer
                {
                    Name = producerDto.Name,
                    Pseudonym = producerDto.Pseudonym,
                    PhoneNumber = producerDto.PhoneNumber,
                    Albums = producerDto.Albums.Select(x => new Album
                    {
                        ReleaseDate = DateTime.ParseExact(x.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Name = x.Name
                    })
                    .ToArray()
                };

                producers.Add(producer);
                if (producer.PhoneNumber != null)
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count));
                }
                else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count));
                }
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSongsDto[]), new XmlRootAttribute("Songs"));

            var songsDtos = (ImportSongsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var songs = new List<Song>();

            foreach (var songsDto in songsDtos)
            {
                if (!IsValid(songsDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!Enum.TryParse<Genre>(songsDto.Genre, out Genre genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var album = context.Albums.FirstOrDefault(x => x.Id == songsDto.AlbumId);
                var writer = context.Writers.FirstOrDefault(x => x.Id == songsDto.WriterId);

                if (album == null || writer == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song
                {
                    Name = songsDto.Name,
                    Genre = genre,
                    Duration = TimeSpan.ParseExact(songsDto.Duration, "c", CultureInfo.InvariantCulture),
                    CreatedOn = DateTime.ParseExact(songsDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Writer = writer,
                    Album = album,
                    Price = songsDto.Price
                };

                songs.Add(song);
                sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPerformerDto[]), new XmlRootAttribute("Performers"));

            var performerDtos = (ImportPerformerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var performers = new List<Performer>();

            foreach (var performerDto in performerDtos)
            {
                if (!IsValid(performerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var performer = new Performer
                {
                    Age = performerDto.Age,
                    FirstName = performerDto.FirstName,
                    LastName = performerDto.LastName,
                    NetWorth = performerDto.NetWorth,
                    //PerformerSongs = performerDto.PerformersSongs.Select(x => new SongPerformer
                    //{
                    //    SongId = x.Id
                    //}).ToArray()
                };
                var isValidSong = true;

                foreach (var currentSong in performerDto.PerformersSongs)
                {
                    var song = context.Songs.FirstOrDefault(x => x.Id == currentSong.Id);

                    if (song == null)
                    {
                        isValidSong = false;
                        sb.AppendLine(ErrorMessage);
                        break;
                    }
                    var songPerformer = new SongPerformer
                    {
                        Song = song,
                        Performer = performer
                    };
                    performer.PerformerSongs.Add(songPerformer);
                }

                if (!isValidSong)
                {
                    continue;
                }

                performers.Add(performer);
                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName, performer.PerformerSongs.Count));
            }

            context.Performers.AddRange(performers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
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