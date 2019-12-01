namespace SoftJail.Data.Models
{
    using Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Officer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30), MinLength(3)]
        public string FullName { get; set; }

        [Range(0, (double)decimal.MaxValue)]
        public decimal Salary { get; set; }

        public Position Position { get; set; }

        public Weapon Weapon { get; set; }

        public int DepartmentId { get; set; }
        
        [Required]
        public Department Department { get; set; }

        public ICollection<OfficerPrisoner> OfficerPrisoners { get; set; } = new HashSet<OfficerPrisoner>();
    }
}
