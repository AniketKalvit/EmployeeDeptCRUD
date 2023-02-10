using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CRUDUsingADO.Models
{
    [Table("tblEmployee")]
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        
        [Required]
        [Display(Name="Employee Name")]
        [MaxLength(40)]
        [MinLength(2)]
        public string? Name { get; set; } // ? is for to allow null from DB

        [Required]
        [MaxLength(10)]
        public string? Mobile { get; set; }

        [Required]
        [MaxLength(40)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string? City { get; set; }
        [Required]
        public string? Gender { get; set; }

        [Required]
        public double Salary { get; set; }

        [ScaffoldColumn(false)]
        public int IsActive { get; set; }
        public int DeptId { get; set; }

        [NotMapped]
        public string? DeptName { get; set; }
    }
}
