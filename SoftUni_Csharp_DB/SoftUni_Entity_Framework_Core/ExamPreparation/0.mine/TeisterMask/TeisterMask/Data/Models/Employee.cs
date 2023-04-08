using System.ComponentModel.DataAnnotations;
using TeisterMask.Utilities;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        public Employee()
        {
            this.EmployeesTasks = new HashSet<EmployeeTask>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.EmployeeUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]        
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; }

    }
}
