using SoftJail.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartamentsCellDto
    {
        [Required]
        [Range(ValidationConstants.CellNumberMin, ValidationConstants.CellNumberMax)]
        public int CellNumber { get; set; }

        [Required]
        public bool HasWindow { get; set; }
    }
}
