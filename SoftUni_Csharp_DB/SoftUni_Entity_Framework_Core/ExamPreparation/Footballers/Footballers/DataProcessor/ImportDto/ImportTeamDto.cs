namespace Footballers.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Shared;
    public class ImportTeamDto
    {
        [Required]
        [MinLength(GlobalConstants.TeamNameMinLength)]
        [MaxLength(GlobalConstants.TeamNameMaxLength)]
        [RegularExpression(GlobalConstants.TeamNameRegex)]
        public string Name { get; set; }

        [Required]
        [MinLength(GlobalConstants.TeamNameMinLength)]
        [MaxLength(GlobalConstants.TeamNameMaxLength)]
        public string Nationality { get; set; }


        [Required]
        public int Trophies { get; set; }

        public int[] Footballers { get; set; }
    }
}
