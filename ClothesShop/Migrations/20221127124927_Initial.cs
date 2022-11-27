using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClothesShop.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Designers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProfilePictureUrl = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Bio = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FashionHouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProfilePictureUrl = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Bio = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FashionHouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ClothesCategory = table.Column<int>(type: "INTEGER", nullable: false),
                    FashionHouseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clothes_FashionHouses_FashionHouseId",
                        column: x => x.FashionHouseId,
                        principalTable: "FashionHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Designers_Clothes",
                columns: table => new
                {
                    ClothesId = table.Column<int>(type: "INTEGER", nullable: false),
                    DesignerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designers_Clothes", x => new { x.DesignerId, x.ClothesId });
                    table.ForeignKey(
                        name: "FK_Designers_Clothes_Clothes_ClothesId",
                        column: x => x.ClothesId,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Designers_Clothes_Designers_DesignerId",
                        column: x => x.DesignerId,
                        principalTable: "Designers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Designers",
                columns: new[] { "Id", "Bio", "FullName", "ProfilePictureUrl" },
                values: new object[,]
                {
                    { 1, "This is the Bio of the first designer", "Designer 1", "https://media.istockphoto.com/id/1226359172/pl/zdj%C4%99cie/gdzie%C5%9B-czeka-mnie-lepsza-przysz%C5%82o%C5%9B%C4%87.jpg?s=612x612&w=is&k=20&c=NwsymUIdac6wZdUPBjJ4DN8Yf_nSCBSwMcwHZImHd1k=" },
                    { 2, "This is the Bio of the second designer", "Designer 2", "https://www.istockphoto.com/pl/zdj%C4%99cie/pozytywny-sukces-millenials%C3%B3w-biznesmen-profesjonalny-m%C4%99%C5%BCczyzna-portret-gm1388253782-445953938" }
                });

            migrationBuilder.InsertData(
                table: "FashionHouses",
                columns: new[] { "Id", "Bio", "FullName", "ProfilePictureUrl" },
                values: new object[,]
                {
                    { 1, "This is the Bio of the first Fashion House", "Fashion house 1", "https://media.istockphoto.com/id/1194258483/pl/wektor/abstrakcyjne-logo-technologii-po%C5%82%C4%85cze%C5%84-cyfrowych-litera-o-logotyp-prosta-zaawansowana.jpg?s=612x612&w=is&k=20&c=dnNV9bED480YcHzqTTKnwdX8rE85RDqPUH10rA_Q0EQ=" },
                    { 2, "This is the Bio of the second Fashion House", "Fashion house 2", "https://media.istockphoto.com/id/1180155588/pl/wektor/szablon-projektu-wektorowego-dla-firm-ikona-abstrakcyjna-pracy-zespo%C5%82owych.jpg?s=612x612&w=is&k=20&c=bH5_8nOJ6yLMSBUbI4IxQYoWUbnNkVNRuXmnlRfyWx4=" }
                });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "ClothesCategory", "Description", "FashionHouseId", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 2, "Description of first item", 1, "https://media.istockphoto.com/id/1142211733/pl/zdj%C4%99cie/przednia-bluza-z-kapturem-izolowanym-na-bia%C5%82ym-tle.jpg?s=612x612&w=is&k=20&c=YKldkNoeUyMkJeacF7SZFhwSEdlC2umtNpL7bEIjbXg=", "First item", 30.989999999999998 },
                    { 2, 3, "Description of second item", 2, "https://media.istockphoto.com/id/864713752/pl/zdj%C4%99cie/czapka-bejsbolowa.jpg?s=612x612&w=is&k=20&c=FXED6sj8D3CcXfD2022-sQI-SEQ4MQf4P8OHk04hSM4=", "Second item", 50.0 }
                });

            migrationBuilder.InsertData(
                table: "Designers_Clothes",
                columns: new[] { "ClothesId", "DesignerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_FashionHouseId",
                table: "Clothes",
                column: "FashionHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Designers_Clothes_ClothesId",
                table: "Designers_Clothes",
                column: "ClothesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Designers_Clothes");

            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DropTable(
                name: "Designers");

            migrationBuilder.DropTable(
                name: "FashionHouses");
        }
    }
}
