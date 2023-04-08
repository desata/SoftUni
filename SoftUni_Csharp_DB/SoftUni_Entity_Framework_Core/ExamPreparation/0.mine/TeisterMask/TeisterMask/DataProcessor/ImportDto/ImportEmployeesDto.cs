using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeisterMask.Utilities;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeesDto
    {
        [Required]
        [MinLength(ValidationConstants.EmployeeUsernameMinLength)]
        [MaxLength(ValidationConstants.EmployeeUsernameMaxLength)]
        [RegularExpression(ValidationConstants.EmployeeUsernameRegex)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.EmployeePhoneRegex)]
        public string Phone { get; set; }

        [Required]
        public int[] Tasks { get; set; }

    }
}
