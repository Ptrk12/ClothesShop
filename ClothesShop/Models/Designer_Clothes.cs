namespace ClothesShop.Models
{
    public class Designer_Clothes
    {
        public int ClothesId { get; set; }
        public Clothes Clothes { get; set; }
        public int DesignerId { get; set; }
        public Designer Designer { get; set; }
    }
}
