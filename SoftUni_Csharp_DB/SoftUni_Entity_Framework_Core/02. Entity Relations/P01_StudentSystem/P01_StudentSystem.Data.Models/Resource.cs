using P01_StudentSystem.Data.Common;
using P01_StudentSystem.Data.Models.Enum;
using System.ComponentModel.DataAnnotations;


namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        [MaxLength(ValidationConstants.ResourceNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ValidationConstants.ResourceUrlMaxLength)]
        public string? Url { get; set; }

        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;

    }
}
