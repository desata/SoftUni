using System.ComponentModel.DataAnnotations;
using Trucks.Utilities;

namespace Trucks.Data.Models
{
    public class Client
    {
        public Client()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }

        public int Id { get; set; }

        [MaxLength(ValidationConstants.ClientNameMaxLength)]
        [Required]
        public string Name { get; set; } = null!;

        [MaxLength(ValidationConstants.ClientNationalityMaxLength)]
        [Required]
        public string Nationality  { get; set; } = null!;

        public string? Type { get; set; }

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }

    }
}
