using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace Inventory.Mvc.Models
{
    public class ProductViewModel : EditImageViewModel
    {
        [DisplayName("ProductName")]
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [DisplayName("Price")]
        [Required]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "PLease enter category name")]
        public string? CategoryName { get; set; }
    }
} 