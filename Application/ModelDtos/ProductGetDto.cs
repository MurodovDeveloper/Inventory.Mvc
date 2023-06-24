using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ModelDtos
{

    public class ProductGetDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
       
        public string? ProductImage { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
