using SoftJail.Data.Models.Enums;
using SoftJail.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class Officer
    {
        public Officer()
        {
            this.OfficerPrisoners = new HashSet<OfficerPrisoner>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.OfficerFullNameLengthMax)]
        public string FullName { get; set; } = null!;

        public decimal Salary { get; set; }

        [Required]
        public Position Position { get; set; }

        [Required]
        public Weapon Weapon { get; set; }

        [Required]
        [ForeignKey(nameof(Department))]
        public int DepartmentId  { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<OfficerPrisoner> OfficerPrisoners  { get; set; }
    }
}
