using ClothesShop.Models;

namespace ClothesShop.Data.ViewModels
{
    public class NewClothesDropDownsVm
    {
        public NewClothesDropDownsVm()
        {
            FashionHouses = new List<FashionHouse>();
            Designers = new List<Designer>();
        }
        public List<FashionHouse> FashionHouses { get; set; }
        public List<Designer> Designers { get; set; }
        
    }
}
