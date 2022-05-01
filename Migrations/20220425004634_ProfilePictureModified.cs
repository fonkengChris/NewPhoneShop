using Microsoft.EntityFrameworkCore.Migrations;

namespace NewPhoneShop2.Migrations
{
    public partial class ProfilePictureModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemPictureURL",
                table: "Products",
                newName: "ProfilePictureURL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePictureURL",
                table: "Products",
                newName: "ItemPictureURL");
        }
    }
}
