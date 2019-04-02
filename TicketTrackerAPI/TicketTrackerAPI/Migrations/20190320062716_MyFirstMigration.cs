using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketTrackerAPI.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ticketmaster",
                columns: table => new
                {
                    TicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientName = table.Column<string>(maxLength: 50, nullable: true),
                    DeveloperName = table.Column<string>(maxLength: 50, nullable: true),
                    Module = table.Column<string>(maxLength: 50, nullable: true),
                    DEscription = table.Column<string>(maxLength: 500, nullable: true),
                    ShortNotes = table.Column<string>(maxLength: 50, nullable: true),
                    priority = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticketmaster", x => x.TicketId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticketmaster");
        }
    }
}
