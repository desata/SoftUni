namespace Footballers.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Coach")]
    public class ExportCoachDto
    {
        [XmlElement("CoachName")]
        public string Name { get; set; }

        [XmlAttribute("FootballersCount")]
        public int FootballersCount { get; set; }

        [XmlArray("Footballers")]
        public ExportCoachFootballerDto[] Footballers { get; set; }
    }
}
