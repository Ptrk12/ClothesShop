using ClothesShop.Data.Base;
using ClothesShop.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesShop.Models
{
    public class Clothes:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public ClothesCategory ClothesCategory { get; set; }

        public List<Designer_Clothes> Designer_Clothes { get; set; }

        public int FashionHouseId { get; set; }
        [ForeignKey("FashionHouseId")]
        public FashionHouse FashionHouse { get; set; }
    }
}
