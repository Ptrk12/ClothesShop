using ClothesShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Clothes).Where(x => x.UserId == userId).ToListAsync();
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAdress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAdress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ClothesId = item.Clothes.Id,
                    OrderId = order.Id,
                    Price = item.Clothes.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
