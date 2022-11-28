using System.ComponentModel.DataAnnotations;

namespace ClothesShop.Models
{
    public class FashionHouse
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Profile picture")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Bio")]
        public string Bio { get; set; }

        public List<Clothes> Clothes { get; set; }
    }
}
