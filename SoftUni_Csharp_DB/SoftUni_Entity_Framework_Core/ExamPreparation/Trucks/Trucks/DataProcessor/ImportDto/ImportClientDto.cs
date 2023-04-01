namespace Trucks.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Shared;
    public class ImportClientDto
    {
        [Required]
        [MinLength(GlobalConstants.ClientNameMinLength)]
        [MaxLength(GlobalConstants.ClientNameMaxLength)]

        public string Name { get; set; }

        [Required]
        [MinLength(GlobalConstants.ClientNationalityMinLength)]
        [MaxLength(GlobalConstants.ClientNationalityMaxLength)]
        public string Nationality { get; set; }

        [Required]
        public string Type { get; set; }

        public int[] Trucks { get; set; }
    }
}
