namespace Footballers.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;

    using AutoMapper;
    using Newtonsoft.Json;

    using Data;
    using Data.Models;
    using DataProcessor.ExportDto;

    using Formatting = Newtonsoft.Json.Formatting;
    using AutoMapper.QueryableExtensions;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FootballersProfile>();
            });
            var mapper = new Mapper(config);

            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCoachDto[]), new XmlRootAttribute("Coaches"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(sb);

            ExportCoachDto[] coachDtos = context
                .Coaches
                .Where(c => c.Footballers.Any())
                .ProjectTo<ExportCoachDto>(config)
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c => c.Name)
                .ToArray();
            xmlSerializer.Serialize(sw, coachDtos, namespaces);
            return sb.ToString().TrimEnd();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context
                .Teams
                .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
                .ToArray()
                .Select(t => new
                {
                    t.Name,
                    Footballers = t.TeamsFootballers
                        .Where(tf => tf.Footballer.ContractStartDate >= date)
                        .ToArray()
                        .OrderByDescending(tf => tf.Footballer.ContractEndDate)
                        .ThenBy(tf => tf.Footballer.Name)
                        .Select(tf => new
                        {
                            FootballerName = tf.Footballer.Name,
                            ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = tf.Footballer.BestSkillType.ToString(),
                            PositionType = tf.Footballer.PositionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(t => t.Footballers.Length)
                .ThenBy(t => t.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }
    }
}
