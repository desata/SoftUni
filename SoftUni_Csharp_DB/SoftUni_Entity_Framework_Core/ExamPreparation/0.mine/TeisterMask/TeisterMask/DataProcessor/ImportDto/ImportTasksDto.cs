using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Utilities;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportTasksDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ValidationConstants.TaskNameMinLength)]
        [MaxLength(ValidationConstants.TaskNameMaxLength)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        [Required]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Required]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Required]
        public int LabelType { get; set; }
    }
}
