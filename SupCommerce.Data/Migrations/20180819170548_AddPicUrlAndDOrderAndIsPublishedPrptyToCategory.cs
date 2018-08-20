using Microsoft.EntityFrameworkCore.Migrations;

namespace SupCommerce.Data.Migrations
{
    public partial class AddPicUrlAndDOrderAndIsPublishedPrptyToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Categories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Categories",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Categories");
        }
    }
}
