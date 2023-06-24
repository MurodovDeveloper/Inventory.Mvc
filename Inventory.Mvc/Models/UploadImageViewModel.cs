using System.ComponentModel.DataAnnotations;

namespace Inventory.Mvc.Models
{
    public class UploadImageViewModel
    {
        [Display(Name ="Picture")]
        public IFormFile ProductPicture { get; set; }
    }
}
