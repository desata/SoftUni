using System.ComponentModel.DataAnnotations;
using static Forum.App.Common.ValidationConstants.Post;

namespace Forum.App.Data.Models
{
    public class PostFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}