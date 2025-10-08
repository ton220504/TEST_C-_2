using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_CORE_WEB_SQL.Models
{
    [Table("Test_Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; } 

        [Column(TypeName ="decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; } 
        public string? ImagePath { get; set; }
    }
}
