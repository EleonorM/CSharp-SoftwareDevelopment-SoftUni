namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2:F2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var movieDtos = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);
            var movies = new List<Movie>();
            var sb = new StringBuilder();
            foreach (var movieDto in movieDtos)
            {
                if (!IsValid(movieDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var genre = Enum.Parse<Genre>(movieDto.Genre);

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = genre,
                    Rating = movieDto.Rating,
                    Duration = TimeSpan.Parse(movieDto.Duration),
                    Director = movieDto.Director
                };
                movies.Add(movie);

                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDtos = JsonConvert.DeserializeObject<ImportHallsDto[]>(jsonString);
            var halls = new List<Hall>();
            var sb = new StringBuilder();
            foreach (var hallDto in hallsDtos)
            {
                if (!IsValid(hallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is3D = hallDto.Is3D,
                    Is4Dx = hallDto.Is4Dx
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    var seat = new Seat { Hall = hall };
                    hall.Seats.Add(seat);
                }

                halls.Add(hall);

                var projectionType = string.Empty;
                if (hall.Is3D)
                {
                    projectionType = "3D";
                }
                else if (hall.Is4Dx)
                {
                    projectionType = "4Dx";
                }
                else if (hall.Is4Dx && hall.Is3D)
                {
                    projectionType = "4Dx/3D";
                }
                else
                {
                    projectionType = "Normal";
                }

                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, projectionType, hall.Seats.Count));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));

            var projectionDtos = (ImportProjectionDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var projections = new List<Projection>();

            foreach (var projectionDto in projectionDtos)
            {
                if (!IsValid(projectionDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = context.Movies.FirstOrDefault(x => x.Id == projectionDto.MovieId);
                var hall = context.Halls.FirstOrDefault(x => x.Id == projectionDto.HallId);

                if (movie == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    Hall = hall,
                    Movie = movie,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projections.Add(projection);
                sb.AppendLine(string.Format(SuccessfulImportProjection, projection.Movie.Title, projection.DateTime.ToString("MM/dd/yyyy")));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            var customerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var customers = new List<Customer>();

            foreach (var customerDto in customerDtos)
            {
                if (!IsValid(customerDto) || !customerDto.Tickets.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance,
                    Tickets = customerDto.Tickets.Select(t => new Ticket
                    {
                        Price = t.Price,
                        ProjectionId = t.ProjectionId,
                       
                    })
                    .ToArray()

                };

                //var tickets = customerDto.Tickets.Select(t => new Ticket
                //{
                //    Price = t.Price,
                //    ProjectionId = t.ProjectionId,
                //    Customer = customer
                //})
                //    .ToArray();
                //customer.Tickets = tickets;

                customers.Add(customer);
                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName,customer.LastName,customer.Tickets.Count));
            }

            context.Customers.AddRange(customers);
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