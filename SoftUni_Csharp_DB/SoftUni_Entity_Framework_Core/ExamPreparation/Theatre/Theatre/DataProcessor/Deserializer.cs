namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;
    using System.Linq;
    using Theatre.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";



        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var validGenres = new string[] { "Drama", "Comedy", "Romance", "Musical" };
            var minimumTime = new TimeSpan(1, 0, 0);

            var deserializer = new XmlSerializer(typeof(PlayDto[]), new XmlRootAttribute("Plays"));
            var objects = (PlayDto[])deserializer.Deserialize(new StringReader(xmlString));
            var plays = new List<Play>();
            var sb = new StringBuilder();

            foreach (var dto in objects)
            {
                var currentTime = TimeSpan.ParseExact(dto.Duration, "c", CultureInfo.InvariantCulture);

                if (!IsValid(dto) ||
                    !validGenres.Contains(dto.Genre) ||
                    (currentTime < minimumTime))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play
                {
                    Title = dto.Title,
                    Duration = TimeSpan.ParseExact(dto.Duration, "c", CultureInfo.InvariantCulture),
                    Rating = dto.Rating,
                    Genre = (Genre)Enum.Parse(typeof(Genre), dto.Genre),
                    Description = dto.Description,
                    Screenwriter = dto.Screenwriter,
                };


                plays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
            }
            context.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var deserializer = new XmlSerializer(typeof(CastsDto[]), new XmlRootAttribute("Casts"));
            var objects = (CastsDto[])deserializer.Deserialize(new StringReader(xmlString));
            var casts = new List<Cast>();
            var sb = new StringBuilder();

            foreach (var dto in objects)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currentCast = new Cast
                {
                    FullName = dto.FullName,
                    IsMainCharacter = bool.Parse(dto.IsMainCharacter),
                    PhoneNumber = dto.PhoneNumber,
                    PlayId = int.Parse(dto.PlayId)
                };

                casts.Add(currentCast);
                var isMainActor = dto.IsMainCharacter == "true" ? "main" : "lesser";
                sb.AppendLine(string.Format(SuccessfulImportActor, dto.FullName, isMainActor));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var theatreTicketsJson = JsonConvert.DeserializeObject<TheatreImportDto[]>(jsonString);
            var theatres = new List<Theatre>();
            var sb = new StringBuilder();

            foreach (var dto in theatreTicketsJson)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theatre = new Theatre
                {
                    Name = dto.Name,
                    NumberOfHalls = dto.NumberOfHalls,
                    Director = dto.Director,
                };
                var tickets = new List<Ticket>();

                foreach (var tc in dto.Tickets)
                {
                    if (!IsValid(tc))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var currenTicket = new Ticket
                    {
                        Price = tc.Price,
                        RowNumber = tc.RowNumber,
                        Theatre = theatre,
                        PlayId = tc.PlayId,
                    };

                    tickets.Add(currenTicket);
                }

                theatre.Tickets = tickets;
                theatres.Add(theatre);
                var totalTickets = theatre.Tickets.Count().ToString();
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, totalTickets));
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
