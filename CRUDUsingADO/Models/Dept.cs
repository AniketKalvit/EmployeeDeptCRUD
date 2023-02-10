using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDUsingADO.Models
{
    [Table("tblDept")]
    public class Dept
    {
        [Key]
        [ScaffoldColumn(false)]
        public int DeptId { get; set; }
        [Required]
        [MaxLength(10)]
        public string? DeptName { get; set; }
    }
}
