using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    [Comment("Library Books")]
    public class Book
    {
        [Comment("BookId")]
        [Key]
        public int Id { get; set; }

        [Comment("Book Title")]
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Comment("Book Author")]
        [Required]
        [MaxLength(50)]
        public string Author { get; set; } = null!;

        [Comment("Book Description")]
        [Required]ASP.NET Core Introduction_SimplePages
        [MaxLength(5000)]
        public string Description { get; set; } = null!;

        [Comment("Book ImageUrl")]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Comment("Book Rating")]
        public decimal Rating { get; set; }


        [Comment("Book CategoryId")]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public List<IdentityUserBook> UsersBooks { get; set; } = new List<IdentityUserBook>();
    }
}

// Id – a unique integer, Primary Key
// Title – a string with min length 10 and max length 50 (required)
// Author – a string with min length 5 and max length 50 (required)
// Description – a string with min length 5 and max length 5000 (required)
// ImageUrl – a string (required)
// Rating – a decimal with min value 0.00 and max value 10.00 (required)
// CategoryId – an integer, foreign key (required)
// Category – a Category (required)
// UsersBooks – a collection of type IdentityUserBook