namespace Footballers.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;
    using Shared;

    public class Footballer
    {
        public Footballer()
        {
            this.TeamsFootballers = new HashSet<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.FootballerNameMaxLength)]

        public string Name { get; set; }

        [Required]
        public DateTime ContractStartDate { get; set; }

        [Required]
        public DateTime ContractEndDate { get; set; }

        [Required]
        public BestSkillType BestSkillType { get; set; }

        [Required]
        public PositionType PositionType { get; set; }

        [Required]
        [ForeignKey("CoachId")]
        public int CoachId { get; set; }
        public Coach Coach { get; set; }
        public ICollection<TeamFootballer> TeamsFootballers { get; set; }

    }
}
