namespace Footballers.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Shared;

    [XmlType("Footballer")]

    public class ImportCoachFootballersDto
    {
        [Required]
        [MinLength(GlobalConstants.FootballerNameMinLength)]
        [MaxLength(GlobalConstants.FootballerNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [XmlElement("ContractStartDate")]
        public string ContractStartDate { get; set; }

        [Required]
        [XmlElement("ContractEndDate")]
        public string ContractEndDate { get; set; }

        [Required]
        [XmlElement("BestSkillType")]
        [Range(0, 4)]
        public int BestSkillType { get; set; }

        [Required]
        [XmlElement("PositionType")]
        [Range(0, 3)]
        public int PositionType { get; set; }



    }
}
