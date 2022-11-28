﻿// <auto-generated />
using ClothesShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClothesShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("ClothesShop.Models.Clothes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClothesCategory")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FashionHouseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FashionHouseId");

                    b.ToTable("Clothes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClothesCategory = 2,
                            Description = "Description of first item",
                            FashionHouseId = 1,
                            ImageUrl = "https://media.istockphoto.com/id/1142211733/pl/zdj%C4%99cie/przednia-bluza-z-kapturem-izolowanym-na-bia%C5%82ym-tle.jpg?s=612x612&w=is&k=20&c=YKldkNoeUyMkJeacF7SZFhwSEdlC2umtNpL7bEIjbXg=",
                            Name = "First item",
                            Price = 30.989999999999998
                        },
                        new
                        {
                            Id = 2,
                            ClothesCategory = 3,
                            Description = "Description of second item",
                            FashionHouseId = 2,
                            ImageUrl = "https://media.istockphoto.com/id/864713752/pl/zdj%C4%99cie/czapka-bejsbolowa.jpg?s=612x612&w=is&k=20&c=FXED6sj8D3CcXfD2022-sQI-SEQ4MQf4P8OHk04hSM4=",
                            Name = "Second item",
                            Price = 50.0
                        });
                });

            modelBuilder.Entity("ClothesShop.Models.Designer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfilePictureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Designers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "This is the Bio of the first designer",
                            FullName = "Designer 1",
                            ProfilePictureUrl = "https://media.istockphoto.com/id/1226359172/pl/zdj%C4%99cie/gdzie%C5%9B-czeka-mnie-lepsza-przysz%C5%82o%C5%9B%C4%87.jpg?s=612x612&w=is&k=20&c=NwsymUIdac6wZdUPBjJ4DN8Yf_nSCBSwMcwHZImHd1k="
                        },
                        new
                        {
                            Id = 2,
                            Bio = "This is the Bio of the second designer",
                            FullName = "Designer 2",
                            ProfilePictureUrl = "https://media.istockphoto.com/id/1309328823/pl/zdj%C4%99cie/headshot-portret-u%C5%9Bmiechni%C4%99tego-m%C4%99%C5%BCczyzny-pracownika-w-biurze.jpg?s=612x612&w=is&k=20&c=eyupE38eXpKITZer2D_XnKtsbWXYZ0u2sVgaifaNQYM="
                        });
                });

            modelBuilder.Entity("ClothesShop.Models.Designer_Clothes", b =>
                {
                    b.Property<int>("DesignerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClothesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DesignerId", "ClothesId");

                    b.HasIndex("ClothesId");

                    b.ToTable("Designers_Clothes");

                    b.HasData(
                        new
                        {
                            DesignerId = 1,
                            ClothesId = 1
                        },
                        new
                        {
                            DesignerId = 2,
                            ClothesId = 1
                        },
                        new
                        {
                            DesignerId = 1,
                            ClothesId = 2
                        });
                });

            modelBuilder.Entity("ClothesShop.Models.FashionHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfilePictureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FashionHouses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "This is the Bio of the first Fashion House",
                            FullName = "Fashion house 1",
                            ProfilePictureUrl = "https://media.istockphoto.com/id/1194258483/pl/wektor/abstrakcyjne-logo-technologii-po%C5%82%C4%85cze%C5%84-cyfrowych-litera-o-logotyp-prosta-zaawansowana.jpg?s=612x612&w=is&k=20&c=dnNV9bED480YcHzqTTKnwdX8rE85RDqPUH10rA_Q0EQ="
                        },
                        new
                        {
                            Id = 2,
                            Bio = "This is the Bio of the second Fashion House",
                            FullName = "Fashion house 2",
                            ProfilePictureUrl = "https://media.istockphoto.com/id/1180155588/pl/wektor/szablon-projektu-wektorowego-dla-firm-ikona-abstrakcyjna-pracy-zespo%C5%82owych.jpg?s=612x612&w=is&k=20&c=bH5_8nOJ6yLMSBUbI4IxQYoWUbnNkVNRuXmnlRfyWx4="
                        });
                });

            modelBuilder.Entity("ClothesShop.Models.Clothes", b =>
                {
                    b.HasOne("ClothesShop.Models.FashionHouse", "FashionHouse")
                        .WithMany("Clothes")
                        .HasForeignKey("FashionHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FashionHouse");
                });

            modelBuilder.Entity("ClothesShop.Models.Designer_Clothes", b =>
                {
                    b.HasOne("ClothesShop.Models.Clothes", "Clothes")
                        .WithMany("Designer_Clothes")
                        .HasForeignKey("ClothesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClothesShop.Models.Designer", "Designer")
                        .WithMany("Designer_Clothes")
                        .HasForeignKey("DesignerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clothes");

                    b.Navigation("Designer");
                });

            modelBuilder.Entity("ClothesShop.Models.Clothes", b =>
                {
                    b.Navigation("Designer_Clothes");
                });

            modelBuilder.Entity("ClothesShop.Models.Designer", b =>
                {
                    b.Navigation("Designer_Clothes");
                });

            modelBuilder.Entity("ClothesShop.Models.FashionHouse", b =>
                {
                    b.Navigation("Clothes");
                });
#pragma warning restore 612, 618
        }
    }
}