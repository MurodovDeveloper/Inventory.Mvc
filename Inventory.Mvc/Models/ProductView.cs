using Inventory.Mvc.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Mvc.Models
{
    public class ProductView
    {
        public Guid ProductId { get; set; }
        [MaxLength(15)]
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        [Required(ErrorMessage = "PLease enter category name")]
        public string? CategoryName { get; set; }
        [Required(ErrorMessage = "Please select a file TTT.")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".jpg", ".png", "jpeg" })]
        public IFormFile? ProductImage { get; set; }   
    }
}
