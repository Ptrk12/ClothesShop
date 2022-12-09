using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace ClothesShop.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int ClothesId { get; set; }
        [ForeignKey("ClothesId")]
        public Clothes Clothes { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
