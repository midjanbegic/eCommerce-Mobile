using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devision.eCommerce.Mobile.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public OrderStatus OrderStatus { get; set; }    
        public ICollection<Product> Products { get; set; }
    }
}
