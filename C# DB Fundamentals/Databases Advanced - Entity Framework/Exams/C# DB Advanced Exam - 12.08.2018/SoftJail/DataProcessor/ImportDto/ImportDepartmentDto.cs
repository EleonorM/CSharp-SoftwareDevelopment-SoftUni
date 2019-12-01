namespace SoftJail.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ImportDepartmentDto
    {
        [Required]
        [MaxLength(25), MinLength(3)]
        public string Name { get; set; }

        public List<CellsDto> Cells { get; set; }
    }

    public class CellsDto
    {
        [Range(1, 1000)]
        public int CellNumber { get; set; }

        public bool HasWindow { get; set; }
    }
}
