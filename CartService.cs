using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Devision.eCommerce.Mobile.Interfaces;
using Devision.eCommerce.Mobile.Models;


namespace Devision.eCommerce.Mobile.Services
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly ISyncLocalStorageService _localStorageSync;
        private readonly IToastService _toastService;
        private readonly IProductService _productService;

        public event Action OnChange;

        public CartService(
            ILocalStorageService localStorage,
            ISyncLocalStorageService localStorageSync,
            IToastService toastService,
            IProductService productService)
        {
            _localStorage = localStorage;
             _localStorageSync = localStorageSync;
            _toastService = toastService;
            _productService = productService;
        }

        public async Task AddToCart(CartItem item)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            var sameItem = cart
                .Find(x => x.Sku == item.Sku);
            if (sameItem == null)
            {
                cart.Add(item);
            }
            else
            {
                sameItem.Quantity += item.Quantity;
            }

            await _localStorage.SetItemAsync("cart", cart);

            var product = await _productService.GetProduct(item.Sku);
            _toastService.ShowSuccess( "Product added: " + product.Name );
            cart.ForEach(p => Console.WriteLine("Items in cart: ", p.Name));

        }

        public async Task <int> GetProductCount()
        {
            var cart = await  _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart != null && cart.Count() > 0)
                return cart.Count();
            else return 0;
        }
        public async Task<List<CartItem>> GetCartItems()
        { 
            var result = new List<CartItem>();
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return result;
            }

            foreach ( var item in cart)
            {
                var product = await _productService.GetProduct(item.Sku);
                var cartItem = new CartItem
                {
                    Sku = item.Sku,
                    Name = item.Name,
                    AccountId = item.AccountId
                };
                
                var variant = cart.Find(x => x.Sku == item.Sku);
                if (variant != null)
                {
                    cartItem.Name = variant.Name;
                    cartItem.SalePrice = variant.SalePrice;
                }

                result.Add(cartItem);
            }

            return result;
        }

        public async Task DeleteItem(CartItem item)
        {
            var cart = await _localStorage.GetItemAsync<List<Product>>("cart");
            if (cart == null)
            {
                return;
            }
            var cartItem = cart.Find(x => x.Sku == item.Sku);
            cart.Remove(cartItem);

            await _localStorage.SetItemAsync("cart", cart);
            OnChange.Invoke();
        }

        public async Task EmptyCart()
        {
            await _localStorage.RemoveItemAsync("cart");
            OnChange.Invoke();
        }
    }
}
