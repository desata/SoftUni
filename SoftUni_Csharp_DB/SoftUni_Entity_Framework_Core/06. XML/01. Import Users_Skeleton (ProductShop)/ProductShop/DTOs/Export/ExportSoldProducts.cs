using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("User")]
    public class ExportSoldProducts
    {
        [XmlElement("firstName")]
        public string? FirstName { get; set; } = null!;

        [XmlElement("lastName")]
        [Required]
        public string LastName { get; set; } = null!;

        [XmlArray("soldProducts")]
        [Required]
        public ExportProductsDto[] SoldProducts { get; set; } = null!;

    }
}
