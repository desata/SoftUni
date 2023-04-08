using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TeisterMask.Utilities;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectsDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ValidationConstants.ProjectNameMinLength)]
        [MaxLength(ValidationConstants.ProjectNameMaxLength)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        [Required]
        public string? DueDate { get; set; }

        [XmlArray("Tasks")]
        public ImportTasksDto[] Tasks { get; set; }
    }
}
