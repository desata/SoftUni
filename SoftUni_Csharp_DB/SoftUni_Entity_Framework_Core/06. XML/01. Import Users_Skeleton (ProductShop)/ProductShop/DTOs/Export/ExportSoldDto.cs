using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("Users")]
    public class ExportUsersCountDto
    {
        [XmlElement("count")]
        public int UsersCount { get; set; }

        [XmlArray("users")]
        public ExportUsersWithProductsDto[] Users { get; set; }
    }

    [XmlType("User")]
    public class ExportUsersWithProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        public ExportProductsCountDto SoldProducts { get; set; }
    }

    [XmlType("SoldProducts")]
    public class ExportProductsCountDto
    {
        [XmlElement("count")]
        public int ProductsCount { get; set; }

        [XmlArray("products")]
        public ProductsDto[] Products { get; set; }
    }

    [XmlType("Product")]
    public class ProductsDto
    {
        [XmlElement("name")]
        public string ProductName { get; set; }

        [XmlElement("price")]
        public decimal ProductPrice { get; set; }
    }
}