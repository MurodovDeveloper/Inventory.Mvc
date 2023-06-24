using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }
    }

}
