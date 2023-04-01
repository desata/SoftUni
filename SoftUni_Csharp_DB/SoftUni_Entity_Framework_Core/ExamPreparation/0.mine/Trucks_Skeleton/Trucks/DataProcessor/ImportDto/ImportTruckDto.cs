using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Utilities;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckDto
    {
        [XmlElement("RegistrationNumber")]
        [MinLength(ValidationConstants.TruckRegistrationNumberLength)]
        [MaxLength(ValidationConstants.TruckRegistrationNumberLength)]
        [RegularExpression(ValidationConstants.TruckPlateRegex)]
        public string? RegistrationNumber { get; set; }

        [XmlElement("VinNumber")]
        [Required]
        [MinLength(ValidationConstants.TruckVinNumberLength)]
        [MaxLength(ValidationConstants.TruckVinNumberLength)]
        public string VinNumber { get; set; } = null!;

        [XmlElement("TankCapacity")]
        [Range(ValidationConstants.TruckTankCapacityMin, ValidationConstants.TruckTankCapacityMax)]
        public int TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        [Range(ValidationConstants.TruckCargoCapacityMin, ValidationConstants.TruckCargoCapacityMax)]
        public int CargoCapacity { get; set; }

        [XmlElement("CategoryType")]
        [Range(ValidationConstants.TruckCategoryTypeMin, ValidationConstants.TruckCategoryTypeMax)]
        public int CategoryType { get; set; }

        [XmlElement("MakeType")]
        [Range(ValidationConstants.TruckMakeTypeMin, ValidationConstants.TruckMakeTypeMax)]
        public int MakeType { get; set; }
    }
}
