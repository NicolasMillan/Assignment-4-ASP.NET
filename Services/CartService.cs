using Newtonsoft.Json;
using ScamStore.Models;

namespace ScamStore.Services

{
    public class CartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string _cartSessionKey = "Cart";

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SaveCart(Cart cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);

            _httpContextAccessor.HttpContext.Session.SetString(_cartSessionKey, cartJson);
        }

        public Cart? GetCart()
        {
            var cartJson = _httpContextAccessor.HttpContext.Session.GetString(_cartSessionKey);

            return cartJson == null ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartJson);
        }
    }
}