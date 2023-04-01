
namespace Theatre.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Theatre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public sbyte NumberOfHalls { get; set; }
        [Required]
        [MaxLength(30)]
        public string Director { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
