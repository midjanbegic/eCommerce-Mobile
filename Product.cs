using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devision.eCommerce.Mobile.Models
{
    public class Product
    {
        public int AccountId { get; set; }

        public string Sku { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string ShortDescription { get; set; }

        public decimal RegularPrice { get; set; }
        public decimal SalePrice { get; set; }

        public decimal? Discount { get; set; }
        public DateTime? DiscountEnds { get; set; }

        public decimal StockQuantity { get; set; }
        public ProductStockStatus StockStatus { get; set; }
    }
}
