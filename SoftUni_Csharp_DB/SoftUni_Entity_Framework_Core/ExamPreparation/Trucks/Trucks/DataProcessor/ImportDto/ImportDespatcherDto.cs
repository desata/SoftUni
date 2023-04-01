namespace Trucks.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Shared;

    [XmlType("Despatcher")]
    public class ImportDespatcherDto
    {
        [Required]
        [MinLength(GlobalConstants.DespatcherNameMinLength)]
        [MaxLength(GlobalConstants.DespatcherNameMaxLength)]
        [XmlElement("Name")]

        public string Name { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlArray("Trucks")]
        public ImportDespatcherTrucksDto[] Trucks { get; set; }
    }
}
