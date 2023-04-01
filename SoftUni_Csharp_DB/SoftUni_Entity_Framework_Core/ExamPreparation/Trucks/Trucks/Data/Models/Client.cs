namespace Trucks.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Shared;
    public class Client
    {
        public Client()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ClientNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string Type { get; set; }

        public ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
