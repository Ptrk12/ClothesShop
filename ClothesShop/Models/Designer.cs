using ClothesShop.Data.Base;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ClothesShop.Models
{
    public class Designer:IEntityBase
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage ="Profile picture is required")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage ="Full name is required")]
        [StringLength(25, MinimumLength =3,ErrorMessage ="Full name must be between 3 and 25 chars")]
        public string FullName { get; set; }
        [Display(Name = "Bio")]
        [Required(ErrorMessage ="Biography is required")]
        public string Bio { get; set; }
        public List<Designer_Clothes>? Designer_Clothes { get; set; }
    }
}
