using ClothesShop.Data.Base;
using ClothesShop.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesShop.Models
{
    public class NewClothesVm
    {
        [Required(ErrorMessage ="Name is required")]
        [Display(Description="Movie name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [Display(Description = "Clothes description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Display(Description = "Price")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Picture Url is required")]
        [Display(Description = "Picture url")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Category is required")]
        [Display(Description = "Select a category")]
        public ClothesCategory ClothesCategory { get; set; }
        [Required(ErrorMessage = "Clothes designers are required")]
        [Display(Description = "Select designers")]
        public List<int> DesignerIds { get; set; }
        [Required(ErrorMessage = "Clothes Fashion houses are required")]
        [Display(Description = "Select fashion House")]
        public int FashionHouseId { get; set; }

    }
}
