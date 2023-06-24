using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace Domain.Models
{

  
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName("ProductName")]
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [DisplayName("Price")]
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string ProductPicture { get; set; }
     
        public Guid? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}