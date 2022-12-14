using ClothesShop.Data.Enums;
using ClothesShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options):base(options) { }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Designer_Clothes>().HasKey(dc => new
            {
                dc.DesignerId,
                dc.ClothesId
            });

            modelBuilder.Entity<Designer_Clothes>().HasOne(c => c.Clothes)
                .WithMany(dc => dc.Designer_Clothes).HasForeignKey(c => c.ClothesId);

            modelBuilder.Entity<Designer_Clothes>().HasOne(c => c.Designer)
                .WithMany(dc => dc.Designer_Clothes).HasForeignKey(c => c.DesignerId);

            modelBuilder.Entity<Designer>().HasData(
                new Designer()
                {
                    Id=1,
                    ProfilePictureUrl = "https://media.istockphoto.com/id/1226359172/pl/zdj%C4%99cie/gdzie%C5%9B-czeka-mnie-lepsza-przysz%C5%82o%C5%9B%C4%87.jpg?s=612x612&w=is&k=20&c=NwsymUIdac6wZdUPBjJ4DN8Yf_nSCBSwMcwHZImHd1k=",
                    FullName = "Designer 1",
                    Bio = "This is the Bio of the first designer"
                },
                new Designer()
                {
                     Id=2,
                     ProfilePictureUrl = "https://media.istockphoto.com/id/1309328823/pl/zdj%C4%99cie/headshot-portret-u%C5%9Bmiechni%C4%99tego-m%C4%99%C5%BCczyzny-pracownika-w-biurze.jpg?s=612x612&w=is&k=20&c=eyupE38eXpKITZer2D_XnKtsbWXYZ0u2sVgaifaNQYM=",
                     FullName = "Designer 2",
                     Bio = "This is the Bio of the second designer"
                }
                );

            modelBuilder.Entity<FashionHouse>().HasData(
                new FashionHouse()
                {
                    Id=1,
                    ProfilePictureUrl = "https://media.istockphoto.com/id/1194258483/pl/wektor/abstrakcyjne-logo-technologii-po%C5%82%C4%85cze%C5%84-cyfrowych-litera-o-logotyp-prosta-zaawansowana.jpg?s=612x612&w=is&k=20&c=dnNV9bED480YcHzqTTKnwdX8rE85RDqPUH10rA_Q0EQ=",
                    FullName = "Fashion house 1",
                    Bio = "This is the Bio of the first Fashion House"
                },
                new FashionHouse()
                {
                    Id=2,
                    ProfilePictureUrl = "https://media.istockphoto.com/id/1180155588/pl/wektor/szablon-projektu-wektorowego-dla-firm-ikona-abstrakcyjna-pracy-zespo%C5%82owych.jpg?s=612x612&w=is&k=20&c=bH5_8nOJ6yLMSBUbI4IxQYoWUbnNkVNRuXmnlRfyWx4=",
                    FullName = "Fashion house 2",
                    Bio = "This is the Bio of the second Fashion House"
                }
                );

            modelBuilder.Entity<Clothes>().HasData(
                new Clothes()
                {
                    Id=1,
                    Name = "First item",
                    Description = "Description of first item",
                    Price = 30.99,
                    ImageUrl = "https://media.istockphoto.com/id/1142211733/pl/zdj%C4%99cie/przednia-bluza-z-kapturem-izolowanym-na-bia%C5%82ym-tle.jpg?s=612x612&w=is&k=20&c=YKldkNoeUyMkJeacF7SZFhwSEdlC2umtNpL7bEIjbXg=",
                    FashionHouseId = 1,
                    ClothesCategory = ClothesCategory.Hoodie,

                },
                new Clothes()
                {
                    Id=2,
                    Name = "Second item",
                    Description = "Description of second item",
                    Price = 50.00,
                    ImageUrl = "https://media.istockphoto.com/id/864713752/pl/zdj%C4%99cie/czapka-bejsbolowa.jpg?s=612x612&w=is&k=20&c=FXED6sj8D3CcXfD2022-sQI-SEQ4MQf4P8OHk04hSM4=",
                    FashionHouseId = 2,
                    ClothesCategory = ClothesCategory.Hat,
                }
                );

            modelBuilder.Entity<Designer_Clothes>().HasData(
                new Designer_Clothes()
                {
                    ClothesId = 1,
                    DesignerId = 1
                },
                new Designer_Clothes()
                {
                    ClothesId = 1,
                    DesignerId = 2
                },
                new Designer_Clothes()
                {
                    ClothesId = 2,
                    DesignerId = 1
                }
                );
            base.OnModelCreating(modelBuilder);
        }
        public string DbPath { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Designer_Clothes> Designers_Clothes { get; set; }
        public DbSet<FashionHouse> FashionHouses { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}
    }
}
