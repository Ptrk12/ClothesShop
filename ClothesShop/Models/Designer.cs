using System.ComponentModel.DataAnnotations;

namespace ClothesShop.Models
{
    public class Designer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Bio")]
        public string Bio { get; set; }
        public List<Designer_Clothes> Designer_Clothes { get; set; }
    }
}
