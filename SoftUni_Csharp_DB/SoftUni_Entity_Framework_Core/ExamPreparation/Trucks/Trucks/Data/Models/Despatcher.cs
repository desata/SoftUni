namespace Trucks.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Shared;

    public class Despatcher
    {
        public Despatcher()
        {
            this.Trucks = new HashSet<Truck>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DespatcherNameMaxLength)]
        public string Name { get; set; }

        public string Position { get; set; }

        public ICollection<Truck> Trucks { get; set; }
    }
}
