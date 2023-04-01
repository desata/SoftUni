namespace Footballers.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Shared;
    public class Team
    {
        public Team()
        {
            this.TeamsFootballers = new HashSet<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.TeamNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public int Trophies { get; set; }

        public ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
