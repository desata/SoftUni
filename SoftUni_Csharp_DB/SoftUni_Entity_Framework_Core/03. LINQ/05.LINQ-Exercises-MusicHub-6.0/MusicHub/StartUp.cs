namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            //string rezult = ExportAlbumsInfo(context, 7);
            string rezult = ExportSongsAboveDuration(context, 4);//Song duration (integer, in seconds). 
            Console.WriteLine(rezult);

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albumsInfo = context.Albums
                .Where(a =>
                a.ProducerId == producerId).ToList()
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate
                    .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProduserName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price.ToString("F2"),
                        WriterName = s.Writer.Name

                    }).OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.WriterName)
                    .ToArray(),
                    AlbumPrice = a.Price.ToString("F2")
                }).ToArray();

            foreach (var ai in albumsInfo)
            {
                sb.AppendLine($"-AlbumName: {ai.Name}");
                sb.AppendLine($"-ReleaseDate: {ai.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {ai.ProduserName}");
                sb.AppendLine($"-Songs:");

                int songNumber = 1;
                foreach (var s in ai.Songs)
                {
                    sb.AppendLine($"---#{songNumber}");
                    sb.AppendLine($"---SongName: {s.SongName}");
                    sb.AppendLine($"---Price: {s.Price}");
                    sb.AppendLine($"---Writer: {s.WriterName}");
                    songNumber++;
                }
                sb.AppendLine($"-AlbumPrice: {ai.AlbumPrice}").ToString().TrimEnd();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int durationSeconds)
        {
            StringBuilder sb = new StringBuilder();

            //receives Song duration (integer, in seconds).
            //Export the songs which are above the given duration.
            //For each Song, export its Name, Performer Full Name, Writer Name, Album Producer and Duration (in format("c")).
            //Sort the Songs by their Name (ascending), and then by Writer (ascending).

            //If a Song has more than one Performer, export all of them and sort them (ascending).

            //If there are no Performers for a given song, don't print the "---Performer" line at all.;

            var songsExport = context.Songs
                .AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > durationSeconds)                
                .Select(s => new
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performers = s.SongPerformers
                    .Select(p => $"{p.Performer.FirstName} {p.Performer.LastName}")
                    .OrderBy(p => p)
                    .ToArray(),
                    AlbumProducer = s.Album.Producer!.Name,
                    Duration = s.Duration.ToString("c")
                }).OrderBy(s => s.SongName).ThenBy(s => s.Writer).ToArray();

            int songNumber = 1;

            foreach (var se in songsExport)
            {

                sb.AppendLine($"-Song #{songNumber}");
                sb.AppendLine($"---SongName: {se.SongName}");
                sb.AppendLine($"---Writer: {se.Writer}");
                foreach (var performer in se.Performers)
                {                
                  sb.AppendLine($"---Performer: {performer}");
                    
                }
                sb.AppendLine($"---AlbumProducer: {se.AlbumProducer}");
                sb.AppendLine($"---Duration: {se.Duration}");


                songNumber++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
