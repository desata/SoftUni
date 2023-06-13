using System.ComponentModel.DataAnnotations;
using static Forum.App.Common.ValidationConstants.Post;

namespace Forum.App.Data.Models.Post;

public class Post
{
    public int Id { get; init; }

    [Required]
    [MaxLength(TitleMaxLength)]      
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(ContentMaxLength)]
    public string Content { get; set; } = null!;
}
