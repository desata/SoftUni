using System.ComponentModel.DataAnnotations;


namespace Trucks.Data.Models
{
    public class Client
    {
        public Client()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }

        public int Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string Name { get; set; } = null!;

        [MaxLength(40)]
        [Required]
        public string Nationality  { get; set; } = null!;

        public string? Type { get; set; }

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }

    }
}
