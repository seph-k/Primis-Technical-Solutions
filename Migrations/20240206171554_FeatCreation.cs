using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Primis_Technical_Solutions.Migrations
{
    /// <inheritdoc />
    public partial class FeatCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Our_Features",
                newName: "Short_Description");

            migrationBuilder.AddColumn<string>(
                name: "Long_Description",
                table: "Our_Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Long_Description",
                table: "Our_Features");

            migrationBuilder.RenameColumn(
                name: "Short_Description",
                table: "Our_Features",
                newName: "Description");
        }
    }
}
