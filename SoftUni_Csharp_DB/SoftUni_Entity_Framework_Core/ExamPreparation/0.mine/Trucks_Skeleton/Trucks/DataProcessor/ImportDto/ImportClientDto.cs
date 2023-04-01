using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Trucks.Data.Models;
using Trucks.Utilities;

namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(ValidationConstants.ClientNameMinLength)]
        [MaxLength(ValidationConstants.ClientNameMaxLength)]
        public string Name { get; set; } = null!;

        [JsonProperty("Nationality")]
        [Required]
        [MinLength(ValidationConstants.ClientNationalityMinLength)]
        [MaxLength(ValidationConstants.ClientNationalityMaxLength)]
        public string Nationality { get; set; } = null!;

        [JsonProperty("Type")]
        [Required]
        public string Type { get; set; } = null!;

        [JsonProperty("Trucks")]
        public virtual int[] TrucksIds { get; set; }

    }
}
