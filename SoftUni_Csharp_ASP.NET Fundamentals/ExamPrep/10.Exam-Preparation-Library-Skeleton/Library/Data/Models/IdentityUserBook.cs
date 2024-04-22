using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    public class IdentityUserBook
    {
        [Key]
        [Column(Order = 1)]
        public string CollectorId { get; set; } = null!;

        [ForeignKey("CollectorId")]
        public IdentityUser Collector { get; set; } = null!;

        [Key]
        [Column(Order = 2)]
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book Book = new Book();
    }
}
