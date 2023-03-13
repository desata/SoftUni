using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        

        public Player()
        {
            this.PlayersStatistics = new HashSet<PlayerStatistic>();
        }

        public int PlayerId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PlayerNameMaxLength)]
        public string Name { get; set; } = null!;

        public int SquadNumber { get; set; }


        // Todo FK
        //Should not be NULL!!!
        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; } 

        public virtual Team Team { get; set; } =null!;

        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }

        public virtual Position Position { get; set; } = null!;

        public bool IsInjured { get; set; }

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
    }
}
