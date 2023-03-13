using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class Town
    {
        public Town()
        {
            this.Teams = new HashSet<Team>();
        }
        public int TownId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TownNameMaxLength)]
        public string Name { get; set; } = null!;

        //TODO FOreign key
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;

        public virtual ICollection<Team> Teams { get; set; }
    }
}
