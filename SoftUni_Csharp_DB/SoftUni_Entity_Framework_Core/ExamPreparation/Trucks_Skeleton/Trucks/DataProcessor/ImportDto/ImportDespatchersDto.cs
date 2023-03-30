using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Utilities;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatchersDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(ValidationConstants.DespatcherNameMinLength)]
        [MaxLength(ValidationConstants.DespatcherNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("Position")]
        public string? Position { get; set; } = null!;

        [XmlArray("Trucks")]
        public ImportTruckDto[] Trucks { get; set; }


    }
}
