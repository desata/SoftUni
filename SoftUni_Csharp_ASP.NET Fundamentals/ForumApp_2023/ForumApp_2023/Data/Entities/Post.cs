using System.ComponentModel.DataAnnotations;

namespace ForumApp_2023.Data.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(Data.DataConstraints.TitleMaxLength)]
        [MinLength(Data.DataConstraints.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(Data.DataConstraints.ContentMaxLength)]
        [MinLength(Data.DataConstraints.ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}
