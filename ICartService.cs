using Devision.eCommerce.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devision.eCommerce.Mobile.Interfaces
{
    public interface ICartService
    {
        event Action OnChange;
        Task<List<CartItem>> GetCartItems();

        Task <int> GetProductCount();
        Task AddToCart(CartItem item);
        Task DeleteItem(CartItem item);
        Task EmptyCart();
    }
}