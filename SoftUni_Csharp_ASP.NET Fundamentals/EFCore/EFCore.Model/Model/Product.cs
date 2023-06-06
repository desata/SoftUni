using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace EFCore.Infrastructure.Model
{
    [Comment("Product table")]
    public class Product 
    {
        [Comment("Product ID")]
        [Key]
        public int Id { get; set; }

        [Comment("Product name")]
        [MaxLength(150)]
        [Required]
        public string ProductName { get; set; } = null!;

        [Comment("Product quantity")]
        [Required]
        public int Quantity { get; set; }

        public List<ProductNote> ProductNotes { get; set; } = new List<ProductNote>();
    }
}
