using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Primis_Technical_Solutions.Migrations
{
    /// <inheritdoc />
    public partial class mobiledescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mobileDescription",
                table: "Home_Banners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mobileDescription",
                table: "Home_Banners");
        }
    }
}
