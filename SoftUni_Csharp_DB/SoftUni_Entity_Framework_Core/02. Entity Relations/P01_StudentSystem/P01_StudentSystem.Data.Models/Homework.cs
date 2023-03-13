using P01_StudentSystem.Data.Models.Enum;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        public int HomeworkId { get; set; }

        public string Content { get; set; } = null!;

        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        //FK
        public int StudentId { get; set; }

        public Student? Student { get; set; }

        //FK
        public int CourseId { get; set; }

        public Course? Course { get; set; }


    }
}
