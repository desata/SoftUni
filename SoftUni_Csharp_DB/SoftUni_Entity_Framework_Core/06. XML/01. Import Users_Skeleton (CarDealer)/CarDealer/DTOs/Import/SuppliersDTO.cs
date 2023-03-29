using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Suppliers")]
    public class SuppliersDTO
    {
       // [XmlAttribute("name")]
        public string Name { get; set; }

        public bool IsImporter { get; set; }
    }
}
