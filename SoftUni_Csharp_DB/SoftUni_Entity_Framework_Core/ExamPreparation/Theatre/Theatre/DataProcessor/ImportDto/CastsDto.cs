

namespace Theatre.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Cast")]
    public class CastsDto
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        [XmlElement("FullName")]
        public string FullName { get; set; }

        [XmlElement("IsMainCharacter")]
        public string IsMainCharacter { get; set; }

        [Required]
        [RegularExpression(@"^\+44-(\d{2})-(\d{3})-(\d{4})$")]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [XmlElement("PlayId")]
        public string PlayId { get; set; }
    }
}
