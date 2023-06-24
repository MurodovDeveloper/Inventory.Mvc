using Inventory.Mvc.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Mvc.Models
{
    public class CategoryView
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "ENTER CATEGORY NAME")]
        [MaxLength(15)]
        public string CategoryName { get; set; } = null!;

        [Required(ErrorMessage = "Please select a file TTT.")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".jpg", ".png", "jpeg" })]
        public IFormFile? CategoryImage { get; set; }
    }
}
