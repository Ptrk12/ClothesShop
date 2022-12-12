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
        private readonly IOrdersService _ordersService;
        public OrderController(IClothesService clothesService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _clothesService = clothesService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = "";
            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);
            return View(orders);
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

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _clothesService.GetClothesByIdAsync(id);
            if(item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _clothesService.GetClothesByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAdress = "";

            await _ordersService.StoreOrderAsync(items, userId, userEmailAdress);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }

    }
}
