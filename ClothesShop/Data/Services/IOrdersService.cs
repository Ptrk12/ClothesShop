using ClothesShop.Models;

namespace ClothesShop.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAdress);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
