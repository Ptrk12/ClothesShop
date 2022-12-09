using ClothesShop.Data.Cart;
using ClothesShop.Data.Services;
using ClothesShop.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IClothesService _clothesService;
        private readonly ShoppingCart _shoppingCart;
        public OrderController(IClothesService clothesService, ShoppingCart shoppingCart)
        {
            _clothesService= clothesService;
            _shoppingCart= shoppingCart;
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var result = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(result);
        }
    }
}
