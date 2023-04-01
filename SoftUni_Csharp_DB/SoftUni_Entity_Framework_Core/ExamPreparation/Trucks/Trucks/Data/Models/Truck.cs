namespace Trucks.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;
    using Shared;

    public class Truck
    {
        public Truck()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        public string VinNumber { get; set; }

        public int TankCapacity { get; set; }

        public int CargoCapacity { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public MakeType MakeType { get; set; }

        [Required]
        [ForeignKey("DespatcherId")]
        public int DespatcherId { get; set; }
        public Despatcher Despatcher { get; set; }
        public ICollection<ClientTruck> ClientsTrucks { get; set; }

    }
}
