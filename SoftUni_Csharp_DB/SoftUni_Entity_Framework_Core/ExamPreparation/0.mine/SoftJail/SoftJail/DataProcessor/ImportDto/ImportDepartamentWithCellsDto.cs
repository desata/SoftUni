using SoftJail.Utils;
using System.ComponentModel.DataAnnotations;


namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartamentWithCellsDto
    {
        [Required]
        [MinLength(ValidationConstants.DepartamentNameLengthMin)]
        [MaxLength(ValidationConstants.DepartamentNameLengthMax)]

        public string Name { get; set; }

        [Required]
        public ImportDepartamentsCellDto[] Cells { get; set; }


    }

}
