namespace Theatre.DataProcessor
{

    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var result = context.Theatres.ToArray().Where(x => x.NumberOfHalls >= numbersOfHalls &&
             x.Tickets.Count() >= 20)
             .Select(x => new
             {
                 Name = x.Name,
                 Halls = x.NumberOfHalls,
                 TotalIncome = x.Tickets.Where(x => x.RowNumber <= 5).Sum(x => x.Price),
                 Tickets = x.Tickets.Where(x => x.RowNumber <= 5).Select(t => new
                 {
                     Price = t.Price,
                     RowNumber = t.RowNumber
                 })
                 .OrderByDescending(p => p.Price)
                 .ToArray()
             })
             .OrderByDescending(h => h.Halls)
             .ThenBy(n => n.Name);


            string json = JsonConvert.SerializeObject(result, Formatting.Indented);

            return json;
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportPlaysDto[]), new XmlRootAttribute("Plays"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StringWriter stringWriter = new StringWriter(sb))
            {

                var result = context.Plays.Where(x => x.Rating <= raiting)
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .Select(x => new ExportPlaysDto
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c"),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts.Where(x => x.IsMainCharacter)
                    .Select(a => new ActorsExportDto
                    {
                        FullName = a.FullName,
                        MainCharacter = $"Plays main character in '{x.Title}'."
                    })
                    .OrderByDescending(x => x.FullName)
                    .ToArray()
                }).ToArray();


                xmlSerializer.Serialize(stringWriter, result, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
