using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devision.eCommerce.Mobile.Models
{
    public class ProductVariant
    {
        [JsonIgnore]
        public Product Product { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal RegularPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }
    }
}
