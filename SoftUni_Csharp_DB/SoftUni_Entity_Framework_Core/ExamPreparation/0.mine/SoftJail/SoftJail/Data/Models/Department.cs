using SoftJail.Utils;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class Department
    {
        public Department()
        {
            this.Cells = new HashSet<Cell>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.DepartamentNameLengthMax)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Cell> Cells { get; set; }

    }
}
