﻿using System.ComponentModel.DataAnnotations;

namespace ClothesShop.Models
{
    public class Designer
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public List<Designer_Clothes> Designer_Clothes { get; set; }
    }
}
