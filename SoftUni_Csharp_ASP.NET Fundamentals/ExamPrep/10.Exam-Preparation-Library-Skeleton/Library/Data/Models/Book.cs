using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(0.00, 10.00)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;

        public ICollection<IdentityUserBook> UsersBooks { get; set; } = new List<IdentityUserBook>();
    }
}
