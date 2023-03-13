using P01_StudentSystem.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.StudentsCourses = new HashSet<StudentCourse>();
            this.Homeworks = new HashSet<Homework>();
        }

        public int StudentId { get; set; }

        [MaxLength(ValidationConstants.StudentNameMaxLength)]
        public string Name { get; set; } = null!;

        //TODO:exactly 10 characters, not unicode, not required
        [MaxLength(ValidationConstants.StudentPhoneNumberMaxLength)]
        public string? PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> StudentsCourses { get; set; }

        public ICollection<Homework> Homeworks { get; set; }


    }
}