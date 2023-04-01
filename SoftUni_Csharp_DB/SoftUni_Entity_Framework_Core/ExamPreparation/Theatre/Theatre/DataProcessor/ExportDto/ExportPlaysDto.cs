using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Play")]
    public class ExportPlaysDto
    {
        [XmlAttribute("Title")]
        public string Title { get; set; }
        [XmlAttribute("Duration")]
        public string Duration { get; set; }
        [XmlAttribute("Rating")]
        public string Rating { get; set; }
        [XmlAttribute("Genre")]
        public string Genre { get; set; }

        [XmlArray("Actors")]
        public ActorsExportDto[] Actors { get; set; }
    }

    [XmlType("Actor")]
    public class ActorsExportDto
    {
        [XmlAttribute("FullName")]
        public string FullName { get; set; }
        [XmlAttribute("MainCharacter")]
        public string MainCharacter { get; set; }
    }
}
