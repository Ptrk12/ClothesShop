using ClothesShop.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ClothesShop.Models
{
    public class FashionHouse:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Profile picture")]
        [Required(ErrorMessage ="Profile picture is required")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name ="Full Name")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Full name must be between 3 and 50 chars")]
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }
        [Display(Name = "Bio")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        public List<Clothes>? Clothes { get; set; }
    }
}
