namespace Footballers.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Shared;

    [XmlType("Coach")]
    public class ImportCoachDto
    {
        [Required]
        [MinLength(GlobalConstants.CoachNameMinLength)]
        [MaxLength(GlobalConstants.CoachNameMaxLength)]
        [XmlElement("Name")]

        public string Name { get; set; }

        [XmlElement("Nationality")]
        public string Nationality { get; set; }

        [XmlArray("Footballers")]
        public ImportCoachFootballersDto[] Footballers { get; set; }
    }
}
