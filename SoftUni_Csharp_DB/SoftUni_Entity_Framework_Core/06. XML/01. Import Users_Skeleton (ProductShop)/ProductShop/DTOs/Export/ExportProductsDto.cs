using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("Product")]
    public class ExportProductsDto
    {
        [XmlElement("name")]
        [Required]
        public string Name { get; set; } = null!;

        [XmlElement("price")]
        public decimal Price { get; set;}
    }
}
