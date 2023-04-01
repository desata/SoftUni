namespace Trucks.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Shared;

    [XmlType("Truck")]

    public class ImportDespatcherTrucksDto
    {
        [Required]
        [RegularExpression(GlobalConstants.TruckRegistrationNumberRegex)]
        public string RegistrationNumber { get; set; }

        [Required]
        [StringLength(GlobalConstants.TruckVinNumberLength)]
        public string VinNumber { get; set; }

        [XmlElement("TankCapacity")]
        [Range(950, 1420)]
        public int TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        [Range(5000, 29000)]
        public int CargoCapacity { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        [Range(0, 3)]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("MakeType")]
        [Range(0, 4)]
        public int MakeType { get; set; }
    }
}
