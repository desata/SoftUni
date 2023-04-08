using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeisterMask.Utilities;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        public Project()
        {
            this.Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ProjectNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public DateTime OpenDate { get; set; }

        [Required]
        public DateTime? DueDate { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

    }

}
