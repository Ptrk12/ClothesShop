using System.ComponentModel.DataAnnotations;

namespace ClothesShop.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Clothes Clothes { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
