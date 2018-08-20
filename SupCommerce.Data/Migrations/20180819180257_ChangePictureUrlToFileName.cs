using Microsoft.EntityFrameworkCore.Migrations;

namespace SupCommerce.Data.Migrations
{
    public partial class ChangePictureUrlToFileName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "Categories",
                newName: "FileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Categories",
                newName: "PictureUrl");
        }
    }
}
