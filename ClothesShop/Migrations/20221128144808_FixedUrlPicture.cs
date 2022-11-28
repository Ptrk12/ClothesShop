using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesShop.Migrations
{
    /// <inheritdoc />
    public partial class FixedUrlPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Designers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfilePictureUrl",
                value: "https://media.istockphoto.com/id/1388253782/pl/zdj%C4%99cie/pozytywny-sukces-millenials%C3%B3w-biznesmen-profesjonalny-m%C4%99%C5%BCczyzna-portret.jpg?s=612x612&w=is&k=20&c=-AOu87ZL-bIjsj2EfNPreWWA5f-fWgSnKEemWCTIxfA=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Designers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfilePictureUrl",
                value: "https://www.istockphoto.com/pl/zdj%C4%99cie/pozytywny-sukces-millenials%C3%B3w-biznesmen-profesjonalny-m%C4%99%C5%BCczyzna-portret-gm1388253782-445953938");
        }
    }
}
