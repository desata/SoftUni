using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Library.Data.Models
{
    [Comment("Book's Category")]
    public class Category
    {
        [Comment("Category Id")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Comment("Category Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public List<Book> Books { get; set; } = new List<Book>();
    }
}

//• Has Id – a unique integer, Primary Key
//• Has Name – a string with min length 5 and max length 50 (required)
//• Has Books – a collection of type Books