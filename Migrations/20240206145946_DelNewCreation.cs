using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Primis_Technical_Solutions.Migrations
{
    /// <inheritdoc />
    public partial class DelNewCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banner_Logos",
                columns: table => new
                {
                    Banner_LogoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Top_Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bottom_Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About_Banner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Banner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service_Banner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Table_Banner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner_Logos", x => x.Banner_LogoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banner_Logos");
        }
    }
}
