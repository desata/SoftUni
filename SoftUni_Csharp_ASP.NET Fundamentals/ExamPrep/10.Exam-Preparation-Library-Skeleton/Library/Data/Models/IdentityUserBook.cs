using Library.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{

    [Comment("User's Books")]
    public class IdentityUserBook
    {
        [Comment("UserId")]
        public string CollectorId { get; set; } = null!;

        [Comment("User")]
        [ForeignKey(nameof(CollectorId))]
        public IdentityUser Collector { get; set; } = null!;

        [Comment("BookId")]
        [Required]        
        public int BookId { get; set; }

        [Comment("Book")]
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}

//CollectorId – a string, Primary Key, foreign key (required)
//Collector – IdentityUser
//BookId – an integer, Primary Key, foreign key (required)
//Book – Book