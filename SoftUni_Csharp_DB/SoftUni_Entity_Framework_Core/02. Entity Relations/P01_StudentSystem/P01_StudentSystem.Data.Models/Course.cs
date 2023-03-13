
using P01_StudentSystem.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.StudentsCourses = new HashSet<StudentCourse>();
            this.Resources = new HashSet<Resource>();
            this.Homeworks = new HashSet<Homework>();
        }

        public int CourseId { get; set; }

        [MaxLength(ValidationConstants.CourseNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ValidationConstants.CourseDescriptionMaxLength)]
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<StudentCourse> StudentsCourses { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Homework> Homeworks { get; set; }



    }
}
