using System.Xml.Serialization;
using System.Xml;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Truck")]
    public class ExportTruckDto
    {
        [XmlElement("RegistrationNumber")]
        public string RegistrationNumber { get; set; } = null!;

        [XmlElement("Make")]
        public string Make { get; set; } = null!;
    }
}
