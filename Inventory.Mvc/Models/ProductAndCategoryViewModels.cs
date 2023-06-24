using Domain.Models;

namespace Inventory.Mvc.Models
{
    public class ProductAndCategoryViewModels
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
