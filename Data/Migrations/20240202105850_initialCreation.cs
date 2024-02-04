using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Primis_Technical_Solutions.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact_Reasons",
                columns: table => new
                {
                    Contact_ReasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason_For_Contact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact_Reasons", x => x.Contact_ReasonId);
                });

            migrationBuilder.CreateTable(
                name: "Home_Banners",
                columns: table => new
                {
                    Home_BannerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home_Banners", x => x.Home_BannerId);
                });

            migrationBuilder.CreateTable(
                name: "Introductory_Contents",
                columns: table => new
                {
                    Introductory_ContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Home_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Home_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Introductory_Contents", x => x.Introductory_ContentId);
                });

            migrationBuilder.CreateTable(
                name: "Our_Features",
                columns: table => new
                {
                    Our_FeatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Our_Features", x => x.Our_FeatureId);
                });

            migrationBuilder.CreateTable(
                name: "Our_Industries",
                columns: table => new
                {
                    Our_IndustryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Industry_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indutry_Icon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Our_Industries", x => x.Our_IndustryId);
                });

            migrationBuilder.CreateTable(
                name: "Our_Partners",
                columns: table => new
                {
                    Our_PartnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Partner_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Partner_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Partner_Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Our_Partners", x => x.Our_PartnerId);
                });

            migrationBuilder.CreateTable(
                name: "Our_Sectors",
                columns: table => new
                {
                    Our_SectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Our_Sectors", x => x.Our_SectorId);
                });

            migrationBuilder.CreateTable(
                name: "Our_Sevices",
                columns: table => new
                {
                    Our_SeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Our_Sevices", x => x.Our_SeviceId);
                });

            migrationBuilder.CreateTable(
                name: "Our_Skills",
                columns: table => new
                {
                    Our_SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Our_Skills", x => x.Our_SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Our_Teams",
                columns: table => new
                {
                    Our_TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Our_Teams", x => x.Our_TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Partners_Sections",
                columns: table => new
                {
                    Partners_SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Partner_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Partner_Icon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners_Sections", x => x.Partners_SectionId);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    PortfolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Portfolio_Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.PortfolioId);
                });

            migrationBuilder.CreateTable(
                name: "Team_Members",
                columns: table => new
                {
                    Team_MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team_Members", x => x.Team_MemberId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact_Reasons");

            migrationBuilder.DropTable(
                name: "Home_Banners");

            migrationBuilder.DropTable(
                name: "Introductory_Contents");

            migrationBuilder.DropTable(
                name: "Our_Features");

            migrationBuilder.DropTable(
                name: "Our_Industries");

            migrationBuilder.DropTable(
                name: "Our_Partners");

            migrationBuilder.DropTable(
                name: "Our_Sectors");

            migrationBuilder.DropTable(
                name: "Our_Sevices");

            migrationBuilder.DropTable(
                name: "Our_Skills");

            migrationBuilder.DropTable(
                name: "Our_Teams");

            migrationBuilder.DropTable(
                name: "Partners_Sections");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Team_Members");
        }
    }
}
