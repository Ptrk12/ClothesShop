using ClothesShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider serivces)
        {
            ISession session = serivces.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = serivces.GetService<AppDbContext>();
            string cartId = session.GetString("CartId")?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId
            };
        }

        public void AddItemToCart(Clothes clothes)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.Clothes.Id==clothes.Id
            && x.ShoppingCartId == ShoppingCartId);

            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Clothes = clothes,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();          
        }
        public void RemoveItemFromCart(Clothes clothes)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.Clothes.Id == clothes.Id
           && x.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }              
            }
            _context.SaveChanges();

        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.
                Where(x => x.ShoppingCartId == ShoppingCartId).Include(n => n.Clothes).ToList());
        }
        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId)
                .Select(n => n.Clothes.Price * n.Amount).Sum();
            return total;
        }
        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();

        }
    }
}
