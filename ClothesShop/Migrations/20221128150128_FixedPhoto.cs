using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesShop.Migrations
{
    /// <inheritdoc />
    public partial class FixedPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Designers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfilePictureUrl",
                value: "https://media.istockphoto.com/id/1309328823/pl/zdj%C4%99cie/headshot-portret-u%C5%9Bmiechni%C4%99tego-m%C4%99%C5%BCczyzny-pracownika-w-biurze.jpg?s=612x612&w=is&k=20&c=eyupE38eXpKITZer2D_XnKtsbWXYZ0u2sVgaifaNQYM=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Designers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfilePictureUrl",
                value: "https://media.istockphoto.com/id/1388253782/pl/zdj%C4%99cie/pozytywny-sukces-millenials%C3%B3w-biznesmen-profesjonalny-m%C4%99%C5%BCczyzna-portret.jpg?s=612x612&w=is&k=20&c=-AOu87ZL-bIjsj2EfNPreWWA5f-fWgSnKEemWCTIxfA=");
        }
    }
}
