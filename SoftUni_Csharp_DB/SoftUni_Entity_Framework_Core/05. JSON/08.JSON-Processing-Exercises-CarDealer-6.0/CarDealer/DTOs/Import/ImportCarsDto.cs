using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Import
{
    public class ImportCarsDto
    {
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public long TravelledDistance { get; set; }

        public int[] PartsId { get; set; }
    }
}
