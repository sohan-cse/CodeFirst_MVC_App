using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst_MVC_App.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string ProductName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
    }
}
